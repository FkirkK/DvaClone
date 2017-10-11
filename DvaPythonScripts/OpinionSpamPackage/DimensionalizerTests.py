from unittest import TestCase
from OpinionSpamPackage import OpSpamReader
from OpinionSpamPackage import Dimensionalizer


class DimensionalizerTests(TestCase):

    def setUp(self):
        self.dimensionalizer = Dimensionalizer()
        self.osReader = OpSpamReader()
        self.readReviews = self.osReader.ReadAllFiles()

    def test_dimensionalizes_file_1_correctly(self):
        expectedSetResult = 195
        self.dimensionalizer.DimensionalizeReviewBigramPlus(self.readReviews[0])
        print(self.dimensionalizer.dimensionSet)
        self.assertEqual(len(self.dimensionalizer.dimensionSet), expectedSetResult)

    def test_dimensionalizes_file_11_correctly(self):
        expectedSetResult = 180
        self.dimensionalizer.DimensionalizeReviewBigramPlus(self.readReviews[82])
        print(self.dimensionalizer.dimensionSet)
        self.assertEqual(len(self.dimensionalizer.dimensionSet), expectedSetResult)

    def test_dimensionalizes_file_1_and_11_combined_correctly(self):
        expectedTwoSetsResult = 363
        self.dimensionalizer.DimensionalizeReviewBigramPlus(self.readReviews[0])
        self.dimensionalizer.DimensionalizeReviewBigramPlus(self.readReviews[82])
        self.assertEqual(len(self.dimensionalizer.dimensionSet), expectedTwoSetsResult)
