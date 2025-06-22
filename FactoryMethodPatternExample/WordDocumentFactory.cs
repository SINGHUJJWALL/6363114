using System;

namespace FactoryMethodPatternExample
{
    /// <summary>
    /// Concrete factory for creating Word documents
    /// Implements the Factory Method Pattern for Word document creation
    /// </summary>
    public class WordDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            Console.WriteLine("🏭 WordDocumentFactory: Creating new Word document...");
            Console.WriteLine("   Initializing Microsoft Word document structure");
            Console.WriteLine("   Setting up rich text formatting capabilities");

            return new WordDocument();
        }

        public override string GetFactoryInfo()
        {
            return "Word Document Factory - Creates Microsoft Word (.docx) documents with rich text formatting";
        }
    }
}
