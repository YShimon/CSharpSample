namespace CSharpSample.SampleCode.Attributes
{
    /// <summary>
    /// ジェネリクスサンプルで利用する型
    /// </summary>
    public class SampleModel
    {
        /// <summary>
        /// Property-001
        /// </summary>
        [Sample(Author = "Author001", Affiliation = "Affiliation001")]
        public string Property001 { get; set; }

        /// <summary>
        /// Property-002
        /// </summary>
        [Sample(Author = "Author002", Affiliation = "Affiliation002")]
        public string Property002 { get; set; }
    }
}
