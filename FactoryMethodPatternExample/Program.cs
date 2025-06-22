using System;

namespace FactoryMethodPatternExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║           FACTORY METHOD PATTERN DEMONSTRATION           ║");
            Console.WriteLine("║              Document Management System                   ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");

            try
            {
                // Initialize document manager
                DocumentManager manager = new DocumentManager();

                // Test 1: Show available factories
                manager.ListAvailableFactories();

                // Test 2: Create individual documents
                TestIndividualDocumentCreation(manager);

                // Test 3: Batch document creation
                manager.CreateDocumentBatch();

                // Test 4: Document operations demonstration
                TestDocumentOperations();

                // Test 5: Factory method pattern verification
                TestFactoryMethodPattern();

                // Show final statistics
                manager.ShowDocumentStatistics();

                Console.WriteLine("\n╔═══════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                    TESTS COMPLETED                       ║");
                Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Application Error: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void TestIndividualDocumentCreation(DocumentManager manager)
        {
            Console.WriteLine("\n🧪 TEST 1: Individual Document Creation");
            Console.WriteLine("═══════════════════════════════════════");

            // Create Word document
            IDocument wordDoc = manager.CreateDocument("word", "This is a sample Word document content.");
            wordDoc.DisplayInfo();
            wordDoc.Save();
            wordDoc.Close();

            Console.WriteLine("\n" + new string('─', 60) + "\n");

            // Create PDF document
            IDocument pdfDoc = manager.CreateDocument("pdf", "This PDF contains confidential information.");
            pdfDoc.DisplayInfo();
            pdfDoc.Save();
            pdfDoc.Close();

            Console.WriteLine("\n" + new string('─', 60) + "\n");

            // Create Excel document
            IDocument excelDoc = manager.CreateDocument("excel", "Q1 Sales Data: $125,000");
            if (excelDoc is ExcelDocument excel)
            {
                excel.AddWorksheet("Sales");
                excel.SetActiveWorksheet("Sales");
                excel.AddContent("Q2 Sales Data: $150,000");
            }
            excelDoc.DisplayInfo();
            excelDoc.Save();
            excelDoc.Close();
        }

        static void TestDocumentOperations()
        {
            Console.WriteLine("\n🧪 TEST 2: Document Operations Demonstration");
            Console.WriteLine("════════════════════════════════════════════");

            // Test different factory instances
            WordDocumentFactory wordFactory = new WordDocumentFactory();
            PdfDocumentFactory pdfFactory = new PdfDocumentFactory();
            ExcelDocumentFactory excelFactory = new ExcelDocumentFactory();

            Console.WriteLine($"Word Factory: {wordFactory.GetFactoryInfo()}");
            Console.WriteLine($"PDF Factory: {pdfFactory.GetFactoryInfo()}");
            Console.WriteLine($"Excel Factory: {excelFactory.GetFactoryInfo()}\n");

            // Create documents using direct factory calls
            IDocument doc1 = wordFactory.ProcessDocumentCreation("Direct factory method call test");
            doc1.AddContent("Additional content added after creation");
            doc1.DisplayInfo();
            doc1.Close();
        }

        static void TestFactoryMethodPattern()
        {
            Console.WriteLine("\n🧪 TEST 3: Factory Method Pattern Verification");
            Console.WriteLine("══════════════════════════════════════════════");

            // Demonstrate polymorphism - same interface, different implementations
            DocumentFactory[] factories = {
                new WordDocumentFactory(),
                new PdfDocumentFactory(),
                new ExcelDocumentFactory()
            };

            Console.WriteLine("🔍 Demonstrating polymorphism with factory method pattern:");

            for (int i = 0; i < factories.Length; i++)
            {
                Console.WriteLine($"\n--- Factory {i + 1}: {factories[i].GetType().Name} ---");

                // Same method call, different behavior (polymorphism)
                IDocument doc = factories[i].CreateDocument();
                doc.Open();
                doc.AddContent($"Content created by {factories[i].GetType().Name}");

                Console.WriteLine($"✓ Created: {doc.GetDocumentType()}");
                Console.WriteLine($"✓ Extension: {doc.GetFileExtension()}");

                doc.Close();
            }
        }
    }
}
