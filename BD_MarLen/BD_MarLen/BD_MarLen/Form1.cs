using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Search.Spans;
using Lucene.Net.Store;
using Lucene.Net.Util;

namespace BD_MarLen
{
    public partial class Form1 : Form
    { // Ensures index backwards compatibility
        public static String indexLocation = System.IO.Directory.GetCurrentDirectory();
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

            bool boolfound = false;
            using (NpgsqlConnection conn = new NpgsqlConnection("Server=84.201.147.162; Port=5432; User Id=developer; Password=rtfP@ssw0rd; Database=girls"))
            {
                conn.Open();

                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM movies", conn);
                NpgsqlDataReader dr = cmd.ExecuteReader();
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
                        int.TryParse(reader.GetInt16(2).ToString(), out yearInt);

                        var doc = new Document();
                        doc.Add(new Field("full_name", source_name, StringField.TYPE_STORED));
                        //var word = source.name.Split(' ')[0];
                        foreach (var word in source_name.Split(' '))
                        {
                            if (!String.IsNullOrEmpty(word))
                                doc.Add(new Field("name_word", word, TextField.TYPE_STORED));
                        }
                        doc.Add(new StoredField("id", source_id));
                        doc.Add(new Int32Field("year", yearInt, Field.Store.YES));
                        writer1.AddDocument(doc);
                        this.results.Rows.Add(reader.GetInt32(0), reader.GetString(1), yearInt.ToString());
                    } catch
                    {
                        //
                    }
                   
                }
                
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            var query = this.search_field.Text;
            int queryIsString = 0;
            int.TryParse(query, out queryIsString);

            var oneOfWordsSearchInName = "SELECT * FROM movies WHERE name ILIKE '% ' || @string || ' %' OR name ILIKE @string || ' %' OR name ILIKE '% ' || @string OR name = @string LIMIT 10";
            var partSearchInName = "SELECT * FROM movies WHERE name ILIKE '%' || @string || '%' LIMIT 10";
            var allWordsSearchInName = "SELECT * FROM movies WHERE name = @string LIMIT 10";
            var partSearchOrYearInName = queryIsString == 0 ? "SELECT * FROM movies WHERE name ILIKE '%' || @string || '%' LIMIT 10" : "SELECT * FROM movies WHERE year = "+ query +" LIMIT 10";

            var searchAll = "SELECT* FROM movies";

            Cursor.Current = Cursors.WaitCursor;

            bool boolfound = false;
            using (NpgsqlConnection conn = new NpgsqlConnection("Server=84.201.147.162; Port=5432; User Id=developer; Password=rtfP@ssw0rd; Database=girls"))
            {
                conn.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(oneOfWordsSearchInName, conn); // первый параметр в скобках отвечает за способ поиска

                if (query == " ")
                {
                    cmd = new NpgsqlCommand(searchAll, conn);
                }

                cmd.Parameters.Add("@string", NpgsqlTypes.NpgsqlDbType.Text);
                cmd.Parameters["@string"].Value = query;
                cmd.Parameters.AddWithValue(query);

                NpgsqlDataReader dr = cmd.ExecuteReader();
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
                this.results.Rows.Clear();

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
                    this.results.Rows.Add(reader.GetInt32(0), reader.GetString(1), year);
                }
                

            }

            using (NpgsqlConnection conn = new NpgsqlConnection("Server=84.201.147.162; Port=5432; User Id=developer; Password=rtfP@ssw0rd; Database=girls"))
            {
                conn.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(partSearchInName, conn); // первый параметр в скобках отвечает за способ поиска

                if (query == " ")
                {
                    cmd = new NpgsqlCommand(searchAll, conn);
                }

                cmd.Parameters.Add("@string", NpgsqlTypes.NpgsqlDbType.Text);
                cmd.Parameters["@string"].Value = query;
                cmd.Parameters.AddWithValue(query);

                NpgsqlDataReader dr = cmd.ExecuteReader();
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
                    this.results.Rows.Add(reader.GetInt32(0), reader.GetString(1), year);
                }


            }

            using (NpgsqlConnection conn = new NpgsqlConnection("Server=84.201.147.162; Port=5432; User Id=developer; Password=rtfP@ssw0rd; Database=girls"))
            {
                conn.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(allWordsSearchInName, conn); // первый параметр в скобках отвечает за способ поиска

                if (query == " ")
                {
                    cmd = new NpgsqlCommand(searchAll, conn);
                }

                cmd.Parameters.Add("@string", NpgsqlTypes.NpgsqlDbType.Text);
                cmd.Parameters["@string"].Value = query;
                cmd.Parameters.AddWithValue(query);

                NpgsqlDataReader dr = cmd.ExecuteReader();
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
                    this.results.Rows.Add(reader.GetInt32(0), reader.GetString(1), year);
                }


            }

            using (NpgsqlConnection conn = new NpgsqlConnection("Server=84.201.147.162; Port=5432; User Id=developer; Password=rtfP@ssw0rd; Database=girls"))
            {
                conn.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(partSearchOrYearInName, conn); // первый параметр в скобках отвечает за способ поиска

                if (query == " ")
                {
                    cmd = new NpgsqlCommand(searchAll, conn);
                }

                cmd.Parameters.Add("@string", NpgsqlTypes.NpgsqlDbType.Text);
                cmd.Parameters["@string"].Value = query;
                cmd.Parameters.AddWithValue(query);

                NpgsqlDataReader dr = cmd.ExecuteReader();
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
                    this.results.Rows.Add(reader.GetInt32(0), reader.GetString(1), year);
                }
                Cursor.Current = Cursors.Default;


            }

        }

        private void search_field_TextChanged(object sender, EventArgs e)
        {
            search_but.Enabled = search_field.Text == "" ? false : true;
           
        }

        private void lucene_serach_Click(object sender, EventArgs e)
        {
            int counter = 0;
            this.results.Rows.Clear();
            var query = this.search_field.Text.ToLower();
            var array = query.Split(' ').ToList();
            List<string> res_list = new List<string>();
            var searcher = new IndexSearcher(writer1.GetReader(applyAllDeletes: true));

            //одно слово
            var phrase = new MultiPhraseQuery();
            foreach (var word in array)
            {
                phrase = new MultiPhraseQuery();
                if (!String.IsNullOrEmpty(word))
                {
                    phrase.Add(new Term("name_word", word));
                    var res = searcher.Search(phrase, 10).ScoreDocs;
                    foreach (var hit in res)
                    {
                        var foundDoc = searcher.Doc(hit.Doc);
                        var score = hit.Score;

                        this.results.Rows.Add(foundDoc.GetField("id").GetInt32Value().ToString(), foundDoc.GetValues("full_name")[0], foundDoc.GetField("year").GetInt32Value().ToString());

                      
                    }
                }
            }

            // полное название
            phrase = new MultiPhraseQuery();
            phrase.Add(new Term("full_name", query));
            var hits = searcher.Search(phrase, 10).ScoreDocs;
            foreach (var hit in hits)
            {
                var foundDoc = searcher.Doc(hit.Doc);
                var score = hit.Score;
                this.results.Rows.Add(foundDoc.GetField("id").GetInt32Value().ToString(), foundDoc.GetValues("full_name")[0], foundDoc.GetField("year").GetInt32Value().ToString());
            }

            //части слов
            foreach (var word in array)
            {
                if (!String.IsNullOrEmpty(word))
                {
                    var wild = new WildcardQuery(new Term("name_word", "*" + word + "*"));
                    var res = searcher.Search(wild, 10).ScoreDocs;
                    foreach (var hit in res)
                    {
                        var foundDoc = searcher.Doc(hit.Doc);
                        var score = hit.Score;
                        this.results.Rows.Add(foundDoc.GetField("id").GetInt32Value().ToString(), foundDoc.GetValues("full_name")[0], foundDoc.GetField("year").GetInt32Value().ToString());
                    }
                }
            }

            //год и часть слова
            string year_to_find = "";
            int number = 0;
            foreach (var word in array)
            {
                bool result = Int32.TryParse(word, out number);
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
                    if (!String.IsNullOrEmpty(word))
                    {
                        BooleanQuery booleanQuery = new BooleanQuery();

                        var wild = new WildcardQuery(new Term("name_word", "*" + word + "*"));
                        var num = NumericRangeQuery.NewInt32Range("year", 1, number, number, true, true);

                        booleanQuery.Add(wild, Occur.SHOULD);
                        booleanQuery.Add(num, Occur.SHOULD);
                        var res = searcher.Search(booleanQuery, 10).ScoreDocs;
                        foreach (var hit in res)
                        {
                            var foundDoc = searcher.Doc(hit.Doc);
                            var score = hit.Score;
                            this.results.Rows.Add(foundDoc.GetField("id").GetInt32Value().ToString(), foundDoc.GetValues("full_name")[0], foundDoc.GetField("year").GetInt32Value().ToString());
                        }
                    }
                }
            }
        }
       
        
}
}
