using System;

namespace FactoryMethodPatternExample
{
    /// <summary>
    /// Base interface for all document types
    /// Defines common operations that all documents must support
    /// </summary>
    public interface IDocument
    {
        /// <summary>
        /// Opens the document for editing or viewing
        /// </summary>
        void Open();

        /// <summary>
        /// Saves the document to storage
        /// </summary>
        void Save();

        /// <summary>
        /// Closes the document and releases resources
        /// </summary>
        void Close();

        /// <summary>
        /// Gets the document type information
        /// </summary>
        string GetDocumentType();

        /// <summary>
        /// Gets the file extension for this document type
        /// </summary>
        string GetFileExtension();

        /// <summary>
        /// Adds content to the document
        /// </summary>
        void AddContent(string content);

        /// <summary>
        /// Displays current document information
        /// </summary>
        void DisplayInfo();
    }
}
