from unittest import TestCase
from OpinionSpamPackage import OpSpamReader
from OpinionSpamPackage import Dimensionalizer


class DimensionalizerTests(TestCase):

    def setUp(self):
        self.dimensionalizer = Dimensionalizer()
        self.osReader = OpSpamReader()
        self.readReviews = self.osReader.ReadAllFiles()

    def test_bigramplus_file_1_correctly(self):
        # Arrange
        expectedSetResult = 195

        # Act
        self.dimensionalizer.DimensionalizeReviewBigramPlus(self.readReviews[0])

        # Assert
        self.assertEqual(len(self.dimensionalizer.dimensionSet), expectedSetResult)

    def test_bigramplus_file_82_correctly(self):
        # Arrange
        expectedSetResult = 180

        # Act
        self.dimensionalizer.DimensionalizeReviewBigramPlus(self.readReviews[82])

        # Assert
        self.assertEqual(len(self.dimensionalizer.dimensionSet), expectedSetResult)

    def test_bigramplus_file_1_and_82_combined_correctly(self):
        # Arrange
        expectedTwoSetsResult = 363

        # Act
        self.dimensionalizer.DimensionalizeReviewBigramPlus(self.readReviews[0])
        self.dimensionalizer.DimensionalizeReviewBigramPlus(self.readReviews[82])

        # Assert
        self.assertEqual(len(self.dimensionalizer.dimensionSet), expectedTwoSetsResult)

    def test_CreateDictionary_for_files_1_and_82_has_right_amount(self):
        # Arrange
        expectedNumberOfKeys = 363

        # Act
        self.dimensionalizer.DimensionalizeReviewBigramPlus(self.readReviews[0])
        self.dimensionalizer.DimensionalizeReviewBigramPlus(self.readReviews[82])
        self.dimensionalizer.CreateDictionaryOfWords()

        # Assert
        self.assertEqual(len(self.dimensionalizer.mappingDictionary.keys()), expectedNumberOfKeys)

    def test_CreateDictionary_deletes_old_dictionary(self):
        # Arrange
        expectedNumberOfKeys = 195

        # Act
        self.dimensionalizer.DimensionalizeReviewBigramPlus(self.readReviews[0])
        self.dimensionalizer.CreateDictionaryOfWords()

        # Assert
        self.assertEqual(len(self.dimensionalizer.mappingDictionary.keys()), expectedNumberOfKeys)

        # Re-arrange
        self.dimensionalizer.dimensionSet = set()  # Delete the current dimensionset
        expectedNumberOfKeysAfterNewCreation = 180

        # Re-act
        self.dimensionalizer.DimensionalizeReviewBigramPlus(self.readReviews[82])
        self.dimensionalizer.CreateDictionaryOfWords()

        # Re-assert
        self.assertEqual(len(self.dimensionalizer.mappingDictionary.keys()), expectedNumberOfKeysAfterNewCreation)

    def test_dictionary_maps_words_to_integers(self):
        # Arrange
        index = None

        # Act
        self.dimensionalizer.DimensionalizeReviewBigramPlus(self.readReviews[0])
        self.dimensionalizer.CreateDictionaryOfWords()
        index = self.dimensionalizer.mappingDictionary["hilton"]  # Word from the first review

        # Assert
        self.assertTrue(type(index) is int)
