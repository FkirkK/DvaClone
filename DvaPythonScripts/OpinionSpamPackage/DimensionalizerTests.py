from unittest import TestCase
from OpinionSpamPackage import OpSpamReader
from OpinionSpamPackage import Dimensionalizer


class DimensionalizerTests(TestCase):

    def setUp(self):
        self.dimensionalizer = Dimensionalizer()
        self.osReader = OpSpamReader()
        self.readReviews = self.osReader.ReadAllFiles()

    def test_dimensionalizes_file_1_correctly(self):
        self.dimensionalizer.DimensionalizeReview(self.readReviews[0])
        self.assertEqual(len(self.dimensionalizer.dimensionSet), 197)
