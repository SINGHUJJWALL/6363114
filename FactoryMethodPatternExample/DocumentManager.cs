using System;
using System.Collections.Generic;

namespace FactoryMethodPatternExample
{
    /// <summary>
    /// Document manager that demonstrates the Factory Method Pattern usage
    /// Shows how different factories can be used interchangeably
    /// </summary>
    public class DocumentManager
    {
        private Dictionary<string, DocumentFactory> _factories;
        private List<IDocument> _createdDocuments;

        public DocumentManager()
        {
            _factories = new Dictionary<string, DocumentFactory>();
            _createdDocuments = new List<IDocument>();

            // Register available factories
            RegisterFactory("word", new WordDocumentFactory());
            RegisterFactory("pdf", new PdfDocumentFactory());
            RegisterFactory("excel", new ExcelDocumentFactory());
        }

        /// <summary>
        /// Registers a document factory with a specific key
        /// </summary>
        public void RegisterFactory(string key, DocumentFactory factory)
        {
            _factories[key.ToLower()] = factory;
            Console.WriteLine($"📝 Registered factory: {key} -> {factory.GetFactoryInfo()}");
        }

        /// <summary>
        /// Creates a document using the specified factory type
        /// </summary>
        public IDocument CreateDocument(string documentType, string initialContent = null)
        {
            string key = documentType.ToLower();

            if (_factories.ContainsKey(key))
            {
                Console.WriteLine($"\n🎯 Creating {documentType.ToUpper()} document...");
                Console.WriteLine("═══════════════════════════════════════");

                DocumentFactory factory = _factories[key];
                IDocument document = factory.ProcessDocumentCreation(initialContent);

                _createdDocuments.Add(document);
                Console.WriteLine($"📊 Total documents created: {_createdDocuments.Count}");

                return document;
            }
            else
            {
                throw new ArgumentException($"❌ Unknown document type: {documentType}. Available types: {string.Join(", ", _factories.Keys)}");
            }
        }

        /// <summary>
        /// Lists all available document factories
        /// </summary>
        public void ListAvailableFactories()
        {
            Console.WriteLine("\n📋 AVAILABLE DOCUMENT FACTORIES");
            Console.WriteLine("════════════════════════════════");

            foreach (var factory in _factories)
            {
                Console.WriteLine($"🔹 {factory.Key.ToUpper()}: {factory.Value.GetFactoryInfo()}");
            }
        }

        /// <summary>
        /// Shows statistics about created documents
        /// </summary>
        public void ShowDocumentStatistics()
        {
            Console.WriteLine("\n📊 DOCUMENT CREATION STATISTICS");
            Console.WriteLine("═══════════════════════════════");
            Console.WriteLine($"Total Documents Created: {_createdDocuments.Count}");

            var typeCount = new Dictionary<string, int>();
            foreach (var doc in _createdDocuments)
            {
                string type = doc.GetDocumentType();
                typeCount[type] = typeCount.ContainsKey(type) ? typeCount[type] + 1 : 1;
            }

            foreach (var type in typeCount)
            {
                Console.WriteLine($"  • {type.Key}: {type.Value} document(s)");
            }
        }

        /// <summary>
        /// Demonstrates batch document creation
        /// </summary>
        public void CreateDocumentBatch()
        {
            Console.WriteLine("\n🔄 BATCH DOCUMENT CREATION DEMO");
            Console.WriteLine("═══════════════════════════════");

            string[] documentTypes = { "word", "pdf", "excel" };
            string[] sampleContent = {
                "Welcome to our Word document with rich formatting!",
                "This PDF contains important legal information.",
                "Quarterly sales data and financial projections."
            };

            for (int i = 0; i < documentTypes.Length; i++)
            {
                try
                {
                    CreateDocument(documentTypes[i], sampleContent[i]);
                    Console.WriteLine(); // Add spacing between documents
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Error creating {documentTypes[i]} document: {ex.Message}");
                }
            }
        }
    }
}
