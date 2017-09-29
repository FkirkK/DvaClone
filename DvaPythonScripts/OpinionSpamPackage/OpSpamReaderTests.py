from unittest import TestCase
from OpinionSpamPackage import OpSpamReader


class OpSpamReaderTests(TestCase):

    def setUp(self):
        self.osReader = OpSpamReader()

    def test_reads_1600_files(self):
        readReviews = self.osReader.ReadAllFiles()
        self.assertEqual(len(readReviews), 1600)

    def test_imports_reviews_correctly(self):
        readReviews = self.osReader.ReadAllFiles()

        negativeReviewsCount = len([r for r in readReviews if r.isPositive == False])
        self.assertEqual(negativeReviewsCount, 800)

        positiveReviewsCount = len([r for r in readReviews if r.isPositive])
        self.assertEqual(positiveReviewsCount, 800)

        truthfulReviewsCount = len([r for r in readReviews if r.isTruthful])
        self.assertEqual(truthfulReviewsCount, 800)

        deceitfulReviewsCount = len([r for r in readReviews if r.isTruthful == False])
        self.assertEqual(deceitfulReviewsCount, 800)

    def test_did_not_import_empty_content_or_title(self):
        readReviews = self.osReader.ReadAllFiles()

        emptyContentCount = len([r for r in readReviews if (len(r.content) == 0 or r.content is None)])
        self.assertEqual(emptyContentCount, 0)

        emptyTitleCount = len([r for r in readReviews if (len(r.title) == 0 or r.title is None)])
        self.assertEqual(emptyTitleCount, 0)

