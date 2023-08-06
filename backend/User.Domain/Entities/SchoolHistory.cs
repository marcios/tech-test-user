namespace Users.Domain.Entities
{
    public class SchoolHistory
    {
        private SchoolHistory() { }
        public SchoolHistory(string name, string format, string file, int ?id= null)
        {

            if (!(format.Contains("pdf") || format.Contains("doc")))
                throw new ArgumentException("O Formato do arquivo precisa ser word(doc, docx) ou pdf");

            Name = name;
            Format = format;
            FileBase64 = file;
            if(id.HasValue) this.Id = id.Value; 

        }


        public int Id { get; private set; }
        public string Format { get; private set; }
        public string Name { get; private set; }
        public string FileBase64 { get; private set; }
    }
}
