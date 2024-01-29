namespace DocumentManager.Domain
{
    public class DocumentItem
    {
        public string title { get; set; }
        public string content { get; set; }
    }

    public class Document_Manager
    {

        private readonly Queue<DocumentItem> _documentQueue = new Queue<DocumentItem>();
        public void AddDocument(DocumentItem doc) {

            _documentQueue.Enqueue(doc);
        }
     
        public DocumentItem? ProcessAndRemoveDocumentInQueue()
        {
            DocumentItem documentItem = null;

            if (_documentQueue.Count > 0)
            {

                documentItem = _documentQueue.Dequeue();
            }
            return documentItem;
        }
        public bool IsDocumentAvailable()
        {
            return _documentQueue.Count > 0;
        }
        public int CountItemsInQueue()
        {
            return _documentQueue.Count;
        }

    }
}
