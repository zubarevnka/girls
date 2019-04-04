using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Npgsql;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Util;
using Lucene.Net.QueryParsers.Classic;
using static System.Int32;

namespace BD_MarLen
{
    public partial class Form1 : Form
    {
        // Ensures index backwards compatibility
        public static string indexLocation = System.IO.Directory.GetCurrentDirectory();
        public static FSDirectory dir = FSDirectory.Open(indexLocation);

        public static LuceneVersion AppLuceneVersion = LuceneVersion.LUCENE_48;

        //create an analyzer to process the text
        public static StandardAnalyzer analyzer = new StandardAnalyzer(AppLuceneVersion);

        //create an index writer
        public static IndexWriterConfig indexConfig = new IndexWriterConfig(AppLuceneVersion, analyzer);
        public static IndexWriter writer1 = new IndexWriter(dir, indexConfig);


        public Form1()
        {
            InitializeComponent();

            var boolfound = false;
            using (var conn =
                new NpgsqlConnection(
                    "Server=db.mirvoda.com; Port=5454; User Id=developer; Password=rtfP@ssw0rd; Database=girls"))
            {
                conn.Open();

                var cmd = new NpgsqlCommand("SELECT * FROM movies", conn);
                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    boolfound = true;
                    Console.WriteLine("connection established");
                }

                if (boolfound == false)
                {
                    Console.WriteLine("Data does not exist");
                }

                dr.Close();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    try
                    {
                        var source_id = reader.GetInt32(0);
                        var source_name = reader.GetString(1);
                        var yearInt = 0;
                        TryParse(reader.GetInt16(2).ToString(), out yearInt);

                        var doc = new Document();
                        doc.Add(new TextField("name", source_name, Field.Store.YES));
                        doc.Add(new StoredField("id", source_id));
                        doc.Add(new Int32Field("year", yearInt, Field.Store.YES));
                        writer1.AddDocument(doc);
                        writer1.AddDocument(doc);
                        results.Rows.Add(reader.GetInt32(0), reader.GetString(1), yearInt.ToString());
                    }
                    catch
                    {
                        //
                    }
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            var query = search_field.Text;
            var queryIsString = 0;
            TryParse(query, out queryIsString);

            var oneOfWordsSearchInName =
                 "SELECT * FROM movies WHERE name ILIKE '% ' || @string || ' %' LIMIT 10";
            var partSearchInName = "SELECT * FROM movies WHERE name ILIKE '%' || @string || '%' LIMIT 10";
            var allWordsSearchInName = "SELECT * FROM movies WHERE name = @string LIMIT 10";
            var partSearchOrYearInName = queryIsString == 0
                ? "SELECT * FROM movies WHERE name ILIKE '%' || @string || '%' LIMIT 10"
                : "SELECT * FROM movies WHERE year = " + query + " LIMIT 10";

            var searchAll = "SELECT* FROM movies";

            var resultItems = new List<(int id, string name, string year)>();

            Cursor.Current = Cursors.WaitCursor;

            var boolfound = false;
            using (var conn =
                new NpgsqlConnection(
                    "Server=db.mirvoda.com; Port=5454; User Id=developer; Password=rtfP@ssw0rd; Database=girls"))
            {
                conn.Open();

                var cmd = new NpgsqlCommand(oneOfWordsSearchInName, conn); // первый параметр в скобках отвечает за способ поиска

                if (query == " ")
                {
                    cmd = new NpgsqlCommand(searchAll, conn);
                }

                cmd.Parameters.Add("@string", NpgsqlTypes.NpgsqlDbType.Text);
                cmd.Parameters["@string"].Value = query;
                cmd.Parameters.AddWithValue(query);

                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    boolfound = true;
                    Console.WriteLine("connection established");
                }

                if (boolfound == false)
                {
                    Console.WriteLine("Data does not exist");
                }

                dr.Close();
                var reader = cmd.ExecuteReader();
                results.Rows.Clear();

                while (reader.Read())
                {
                    var year = "";
                    try
                    {
                        year = reader.GetInt16(2).ToString();
                    }
                    catch
                    {
                        year = "";
                    }

                    if(!resultItems.Any(f => f.id == reader.GetInt32(0)))
                        resultItems.Add((reader.GetInt32(0), reader.GetString(1), year));
                }
            }

            using (var conn = new NpgsqlConnection("Server=db.mirvoda.com; Port=5454; User Id=developer; Password=rtfP@ssw0rd; Database=girls"))
            {
                conn.Open();

                var
                    cmd = new NpgsqlCommand(partSearchInName,
                        conn); // первый параметр в скобках отвечает за способ поиска

                if (query == " ")
                {
                    cmd = new NpgsqlCommand(searchAll, conn);
                }

                cmd.Parameters.Add("@string", NpgsqlTypes.NpgsqlDbType.Text);
                cmd.Parameters["@string"].Value = query;
                cmd.Parameters.AddWithValue(query);

                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    boolfound = true;
                    Console.WriteLine("connection established");
                }

                if (boolfound == false)
                {
                    Console.WriteLine("Data does not exist");
                }

                dr.Close();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var year = "";
                    try
                    {
                        year = reader.GetInt16(2).ToString();
                    }
                    catch
                    {
                        year = "";
                    }

                    if (!resultItems.Any(f => f.id == reader.GetInt32(0)))
                        resultItems.Add((reader.GetInt32(0), reader.GetString(1), year));
                }
            }

            using (var conn = new NpgsqlConnection("Server=db.mirvoda.com; Port=5454; User Id=developer; Password=rtfP@ssw0rd; Database=girls"))
            {
                conn.Open();

                var cmd = new NpgsqlCommand(allWordsSearchInName, conn); // первый параметр в скобках отвечает за способ поиска

                if (query == " ")
                {
                    cmd = new NpgsqlCommand(searchAll, conn);
                }

                cmd.Parameters.Add("@string", NpgsqlTypes.NpgsqlDbType.Text);
                cmd.Parameters["@string"].Value = query;
                cmd.Parameters.AddWithValue(query);

                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    boolfound = true;
                    Console.WriteLine("connection established");
                }

                if (boolfound == false)
                {
                    Console.WriteLine("Data does not exist");
                }

                dr.Close();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var year = "";
                    try
                    {
                        year = reader.GetInt16(2).ToString();
                    }
                    catch
                    {
                        year = "";
                    }

                    if (!resultItems.Any(f => f.id == reader.GetInt32(0)))
                        resultItems.Add((reader.GetInt32(0), reader.GetString(1), year));
                }
            }

            using (var conn = new NpgsqlConnection("Server=db.mirvoda.com; Port=5454; User Id=developer; Password=rtfP@ssw0rd; Database=girls"))
            {
                conn.Open();

                var cmd = new NpgsqlCommand(partSearchOrYearInName, conn); // первый параметр в скобках отвечает за способ поиска

                if (query == " ")
                {
                    cmd = new NpgsqlCommand(searchAll, conn);
                }

                cmd.Parameters.Add("@string", NpgsqlTypes.NpgsqlDbType.Text);
                cmd.Parameters["@string"].Value = query;
                cmd.Parameters.AddWithValue(query);

                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    boolfound = true;
                    Console.WriteLine("connection established");
                }

                if (boolfound == false)
                {
                    Console.WriteLine("Data does not exist");
                }

                dr.Close();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var year = "";
                    try
                    {
                        year = reader.GetInt16(2).ToString();
                    }
                    catch
                    {
                        year = "";
                    }

                    if (!resultItems.Any(f => f.id == reader.GetInt32(0)))
                        resultItems.Add((reader.GetInt32(0), reader.GetString(1), year));
                }

                Cursor.Current = Cursors.Default;
            }

            foreach (var resultItem in resultItems)
            {
                results.Rows.Add(resultItem.id, resultItem.name, resultItem.year);
            }
        }

        private void search_field_TextChanged(object sender, EventArgs e)
        {
            search_but.Enabled = search_field.Text == "" ? false : true;
        }

        private void lucene_serach_Click(object sender, EventArgs e)
        {
            results.Rows.Clear();
            var query = search_field.Text.ToLower();
            var array = query.Split(' ').ToList();
            var searcher = new IndexSearcher(writer1.GetReader(applyAllDeletes: true));

            var totalResults = new List<Document>();
            //одно слово
            QueryParser parser = new QueryParser(AppLuceneVersion, "name", analyzer);
            var phrase = new MultiPhraseQuery();
            foreach (var word in array)
            {
                var q = parser.Parse(query);
                if (!String.IsNullOrEmpty(word))
                {
                    var res = searcher.Search(q, 10).ScoreDocs;
                    foreach (var hit in res)
                    {
                        var foundDoc = searcher.Doc(hit.Doc);
                        if (!totalResults.Any(f =>
                            f.GetField("id").GetInt32Value() == foundDoc.GetField("id").GetInt32Value()))
                            totalResults.Add(foundDoc);
                    }
                }
            }

            // полное название
            phrase.Add(new Term("name", query));
            var hits = searcher.Search(phrase, 10).ScoreDocs;
            foreach (var hit in hits)
            {
                var foundDoc = searcher.Doc(hit.Doc);
                if (!totalResults.Any(f => f.GetField("id").GetInt32Value() == foundDoc.GetField("id").GetInt32Value()))
                    totalResults.Add(foundDoc);
            }

            //части слов
            foreach (var word in array)
            {
                if (!string.IsNullOrEmpty(word))
                {
                    var wild = new WildcardQuery(new Term("name", "*" + word + "*"));
                    var res = searcher.Search(wild, 10).ScoreDocs;
                    foreach (var hit in res)
                    {
                        var foundDoc = searcher.Doc(hit.Doc);
                        if (!totalResults.Any(f =>
                            f.GetField("id").GetInt32Value() == foundDoc.GetField("id").GetInt32Value()))
                            totalResults.Add(foundDoc);
                    }
                }
            }

            //год и часть слова
            var year_to_find = "";
            var number = 0;
            foreach (var word in array)
            {
                var result = TryParse(word, out number);
                if (result && number > 1800 && number <= 9999)
                {
                    year_to_find = word;
                    array.RemoveAt(array.IndexOf(word));
                    break;
                }
            }

            Console.WriteLine(number != 0);

            if (number != 0)
            {
                phrase = new MultiPhraseQuery();
                foreach (var word in array)
                {
                    if (!string.IsNullOrEmpty(word))
                    {
                        var booleanQuery = new BooleanQuery();
                        var wild = new WildcardQuery(new Term("name", "*" + word + "*"));
                        var num = NumericRangeQuery.NewInt32Range("year", 1, number, number, true, true);

                        booleanQuery.Add(wild, Occur.SHOULD);
                        booleanQuery.Add(num, Occur.SHOULD);
                        var res = searcher.Search(booleanQuery, 10).ScoreDocs;
                        foreach (var hit in res)
                        {
                            var foundDoc = searcher.Doc(hit.Doc);
                            if (!totalResults.Any(f =>
                                f.GetField("id").GetInt32Value() == foundDoc.GetField("id").GetInt32Value()))
                                totalResults.Add(foundDoc);
                        }
                    }
                }
            }


            foreach (var doc in totalResults)
            {
                results.Rows.Add(doc.GetField("id").GetInt32Value().ToString(),
                    doc.GetValues("name")[0],
                    doc.GetField("year").GetInt32Value().ToString());
            }
        }
    }
}