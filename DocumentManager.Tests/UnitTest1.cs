using DocumentManager.Domain;

namespace DocumentManager.Tests
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        
        [Test]
        public void AddingItemShouldIncreaseQueueCountBy1()
        {
            Document_Manager dm = new();

            int queueCountBefore = dm.CountItemsInQueue();

            DocumentItem item = new DocumentItem();

            dm.AddDocument(item);

            int queueCountAfter = dm.CountItemsInQueue();

            Assert.That(queueCountAfter, Is.EqualTo(queueCountBefore + 1));


        }

        [Test]
        public void RemovingItemShouldDecreaseQueueCountBy1()
        {
            Document_Manager dm = new();

            DocumentItem item = new DocumentItem();

            dm.AddDocument(item);
            int queueCountBefore = dm.CountItemsInQueue();

            dm.ProcessAndRemoveDocumentInQueue();

            int queueCountAfter = dm.CountItemsInQueue();

            Assert.That(queueCountAfter, Is.EqualTo(queueCountBefore - 1));


        }

        [Test]
        public void IsDocumentAvailableShouldReturnFalseWhenQueueIsEmpty()
        {
            Document_Manager dm = new();

            Assert.False(dm.IsDocumentAvailable());


        }

        [Test]
        public void IsDocumentAvailableShouldReturnTrueWhenQueueIsNotEmpty()
        {
            Document_Manager dm = new();

            DocumentItem item = new DocumentItem();

            dm.AddDocument(item);

            Assert.True(dm.IsDocumentAvailable());


        }
    }
}