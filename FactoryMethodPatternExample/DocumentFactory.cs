using System;

namespace FactoryMethodPatternExample
{
    /// <summary>
    /// Abstract factory class that defines the factory method pattern
    /// Subclasses will implement the CreateDocument method for specific document types
    /// </summary>
    public abstract class DocumentFactory
    {
        /// <summary>
        /// Abstract factory method to be implemented by concrete factories
        /// This is the core of the Factory Method Pattern
        /// </summary>
        public abstract IDocument CreateDocument();

        /// <summary>
        /// Template method that uses the factory method
        /// This demonstrates how the factory method is used in a larger workflow
        /// </summary>
        public virtual IDocument ProcessDocumentCreation(string content = null)
        {
            Console.WriteLine($"🏭 Starting document creation process using {GetType().Name}...");

            // Use the factory method (this is where polymorphism happens)
            IDocument document = CreateDocument();

            Console.WriteLine($"✅ Document created successfully: {document.GetDocumentType()}");

            // Perform common operations
            document.Open();

            if (!string.IsNullOrEmpty(content))
            {
                document.AddContent(content);
            }

            return document;
        }

        /// <summary>
        /// Gets information about what type of documents this factory creates
        /// </summary>
        public abstract string GetFactoryInfo();
    }
}
