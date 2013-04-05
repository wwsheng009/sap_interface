using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using DapperExtensions;
using DapperExtensions.Mapper;
using DapperExtensions.Sql;


namespace SAPINTDB.CodeManager
{

    public class CodeVersion
    {
        public string Id { get; set; }
        public string CodeId { get; set; }
        public string Content { get; set; }
        public string Version { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }

        public CodeVersion()
        {
            Id = string.Empty;
            CodeId = string.Empty;
            Content = string.Empty;
            Version = string.Empty;
            Title = string.Empty;
            Desc = string.Empty;
        }
    }
    public class CodeIndex
    {
        public string Id { get; set; }
        public string CodeId { get; set; }
        //public string Title { get; set; }
        public string Content { get; set; }
        //public string Version { get; set; }
        //public string Desc { get; set; }
        public CodeIndex()
        {
            Id = string.Empty;
            Content = string.Empty;
        }
    }


    public class CodeTreeMapper : ClassMapper<CodeTree>
    {
        public CodeTreeMapper()
        {
            Map(c => c.CodeList).Ignore();
            Map(c => c.SubTreeList).Ignore();
            AutoMap();
        }
    }


    public class CodeTree
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        //public string DocumentId { get; set; }
        public String Text { get; set; }
        public String Type { get; set; }

        public List<Code> CodeList { get; set; }
        public List<CodeTree> SubTreeList { get; set; }

        public CodeTree()
        {
            Id = string.Empty;
            ParentId = string.Empty;
            Text = string.Empty;

            Type = string.Empty;
        }
    }

    public enum CodeType { Document, Folder }

    public class CodeMapper : ClassMapper<Code>
    {
        public CodeMapper()
        {
            Map(c => c.VersionList).Ignore();

            AutoMap();


        }
    }
    public class Code
    {
        public string Id { get; set; }
        public string TreeId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Version { get; set; }
        public string Desc { get; set; }
        public string Categery { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastChangeTime { get; set; }
        public string Author { get; set; }

        private bool ReadOnly { get; set; }

        public List<CodeVersion> VersionList { get; set; }

        public Code()
        {
            VersionList = new List<CodeVersion>();

            Id = string.Empty;
            TreeId = string.Empty;
            Title = string.Empty;
            Content = string.Empty;
            Version = string.Empty;
            Title = string.Empty;
            Desc = string.Empty;
            Categery = string.Empty;
            Author = string.Empty;



        }

        public Code(DataRow row)
        {

            if (row != null)
            {
                datatrowToObject(row);
            }


        }

        public Code datatrowToObject(DataRow row)
        {

            if (row.Table.Columns.Contains("content"))
            {
                var code = row["content"];
                if (code != null)
                {
                    this.Content = code.ToString();
                }
            }
            if (row.Table.Columns.Contains("title"))
            {
                var title = row["title"];
                if (title != null)
                {
                    this.Title = title.ToString();
                }
            }

            if (row.Table.Columns.Contains("desc"))
            {
                var desc = row["desc"];
                if (desc != null)
                {
                    this.Desc = desc.ToString();
                }
            }
            if (row.Table.Columns.Contains("id"))
            {
                var id = row["id"];
                if (id != null)
                {
                    // Guid g = Guid.Empty;
                    // Guid.TryParse(id.ToString(), out g);
                    this.Id = id.ToString();
                }
            }
            if (row.Table.Columns.Contains("version"))
            {
                var version = row["version"];
                if (version != null)
                {
                    this.Version = version.ToString();
                }
            }

            // _code = this;
            return this;
            // codelist.Add(this);
        }

        public void getNextVersion()
        {
            if (string.IsNullOrWhiteSpace(this.Version))
            {
                this.Version = "1.0.0";
            }
            else
            {
                int tmver = 100;
                this.Version = this.Version.Replace(".", "");
                if (int.TryParse(this.Version, out tmver))
                {
                    tmver += 1;
                    this.Version = tmver.ToString();
                    this.Version = string.Format("{0}.{1}.{2}", this.Version.Substring(0, 1), this.Version.Substring(1, 1), this.Version.Substring(2, 1));

                }
                else
                {
                    this.Version = tmver.ToString();
                    this.Version = string.Format("{0}.{1}.{2}", this.Version.Substring(0, 1), this.Version.Substring(1, 1), this.Version.Substring(2, 1));
                }


            }

        }
    }

}
