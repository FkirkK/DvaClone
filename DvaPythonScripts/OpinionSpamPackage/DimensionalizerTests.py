from unittest import TestCase
from OpinionSpamPackage import OpSpamReader
from OpinionSpamPackage import UniGramDimensionalizer
from OpinionSpamPackage import BigramDimensionalizer
from OpinionSpamPackage import BigramPlusDimensionalizer
from OpinionSpamPackage import TrigramDimensionalizer
from OpinionSpamPackage import TrigramPlusDimensionalizer


class UnigramDimensionalizerTests(TestCase):

    @classmethod
    def setUpClass(self):
        self.osReader = OpSpamReader()
        self.readReviews = self.osReader.ReadAllFiles()

    def test_getunigrams_returns_proper_set_file_1(self):
        # Arrange
        expectedSetResult = 82
        uniGramDimensionalizer = UniGramDimensionalizer([self.readReviews[0]])

        # Act
        returnedSet = uniGramDimensionalizer.featureGetter(self.readReviews[0])

        # Assert
        self.assertEqual(len(returnedSet), expectedSetResult)

    def test_unigram_file_1_correctly(self):
        validateDimensionalizerSetSize(self, UniGramDimensionalizer, [self.readReviews[0]], expectedSetResult=82)

    def test_unigram_file_82_correctly(self):
        validateDimensionalizerSetSize(self, UniGramDimensionalizer, [self.readReviews[82]], expectedSetResult=79)

    def test_unigram_file_1_and_82_combined_correctly(self):
        validateDimensionalizerSetSize(self, UniGramDimensionalizer, [self.readReviews[0], self.readReviews[82]], expectedSetResult=150)

    def test_CreateDictionary_for_files_1_and_82_has_right_amount(self):
        # Arrange
        expectedNumberOfKeys = 150
        uniGramDimensionalizer = UniGramDimensionalizer([self.readReviews[0], self.readReviews[82]])

        # Act

        # Assert
        self.assertEqual(len(uniGramDimensionalizer.mappingDictionary.keys()), expectedNumberOfKeys)

    def test_dictionary_maps_words_to_integers(self):
        # Arrange
        index = None
        uniGramDimensionalizer = UniGramDimensionalizer([self.readReviews[0]])

        # Act
        index = uniGramDimensionalizer.mappingDictionary["hilton"]  # Word from the first review

        # Assert
        self.assertTrue(type(index) is int)

    def test_CreateVector_for_review_1(self):
        # Arrange
        featureCount = 11933  # Number of unigrams in dataset
        expectedVectorOnesCount = 82  # Number of 1-entries in generated vector
        actualVectorOnesCount = 0
        uniGramDimensionalizer = UniGramDimensionalizer(self.readReviews)

        # Act
        vector = uniGramDimensionalizer.CreateVectorForReview(self.readReviews[0])
        for entry in vector[0]:
            if entry == 1:
                actualVectorOnesCount += 1

        # Assert
        self.assertEqual(len(vector[0]), featureCount)
        self.assertEqual(actualVectorOnesCount, expectedVectorOnesCount)


class BigramDimensionalizerTests(TestCase):

    def setUp(self):
        self.osReader = OpSpamReader()
        self.readReviews = self.osReader.ReadAllFiles()
        self.dimensionalizer = BigramDimensionalizer(self.readReviews)

    def test_getbigrams_returns_proper_set_file_1(self):
        # Arrange
        expectedSetResult = 113

        # Act
        returnedSet = self.dimensionalizer.featureGetter(self.readReviews[0])

        # Assert
        self.assertEqual(len(returnedSet), expectedSetResult)

    def test_bigram_file_1_correctly(self):
        # Arrange
        expectedSetResult = 113

        # Act
        self.dimensionalizer.__DimensionalizeReview__(self.readReviews[0])

        # Assert
        self.assertEqual(len(self.dimensionalizer.dimensionSet), expectedSetResult)

    def test_bigram_file_82_correctly(self):
        # Arrange
        expectedSetResult = 101

        # Act
        self.dimensionalizer.__DimensionalizeReview__(self.readReviews[82])

        # Assert
        self.assertEqual(len(self.dimensionalizer.dimensionSet), expectedSetResult)

    def test_bigram_file_1_and_82_combined_correctly(self):
        # Arrange
        expectedTwoSetsResult = 213

        # Act
        self.dimensionalizer.__DimensionalizeReview__(self.readReviews[0])
        self.dimensionalizer.__DimensionalizeReview__(self.readReviews[82])

        # Assert
        self.assertEqual(len(self.dimensionalizer.dimensionSet), expectedTwoSetsResult)

    def test_bigramALL_with_2_files(self):
        # Arrange
        expectedSetResult = 213
        reviewList = []
        reviewList.append(self.readReviews[0])
        reviewList.append(self.readReviews[82])

        # Act
        self.dimensionalizer.__DimensionalizeAllReviews__(reviewList=reviewList)

        # Assert
        self.assertEqual(len(self.dimensionalizer.dimensionSet), expectedSetResult)

    def test_CreateDictionary_for_files_1_and_82_has_right_amount(self):
        # Arrange
        expectedNumberOfKeys = 213

        # Act
        self.dimensionalizer.__DimensionalizeReview__(self.readReviews[0])
        self.dimensionalizer.__DimensionalizeReview__(self.readReviews[82])
        self.dimensionalizer.CreateDictionaryOfWords()

        # Assert
        self.assertEqual(len(self.dimensionalizer.mappingDictionary.keys()), expectedNumberOfKeys)

    def test_CreateDictionary_deletes_old_dictionary(self):
        # Arrange
        expectedNumberOfKeys = 113

        # Act
        self.dimensionalizer.__DimensionalizeReview__(self.readReviews[0])
        self.dimensionalizer.CreateDictionaryOfWords()

        # Assert
        self.assertEqual(len(self.dimensionalizer.mappingDictionary.keys()), expectedNumberOfKeys)

        # Re-arrange
        self.dimensionalizer.dimensionSet = set()  # Delete the current dimensionset
        expectedNumberOfKeysAfterNewCreation = 101

        # Re-act
        self.dimensionalizer.__DimensionalizeReview__(self.readReviews[82])
        self.dimensionalizer.CreateDictionaryOfWords()

        # Re-assert
        self.assertEqual(len(self.dimensionalizer.mappingDictionary.keys()), expectedNumberOfKeysAfterNewCreation)

    def test_dictionary_maps_words_to_integers(self):
        # Arrange
        index = None

        # Act
        self.dimensionalizer.__DimensionalizeReview__(self.readReviews[0])
        self.dimensionalizer.CreateDictionaryOfWords()
        index = self.dimensionalizer.mappingDictionary["some pizzas"]  # Word from the first review

        # Assert
        self.assertTrue(type(index) is int)

    def test_CreateVector_for_review_1(self):
        # Arrange
        featureCount = 84112  # Number of bigrams in dataset
        expectedVectorOnesCount = 113  # Number of 1-entries in generated vector
        actualVectorOnesCount = 0

        # Act
        self.dimensionalizer.__DimensionalizeAllReviews__(self.readReviews)
        vector = self.dimensionalizer.CreateVectorForReview(self.readReviews[0])
        for entry in vector[0]:
            if entry == 1:
                actualVectorOnesCount += 1

        # Assert
        self.assertEqual(len(vector[0]), featureCount)
        self.assertEqual(actualVectorOnesCount, expectedVectorOnesCount)


class BigramPlusDimensionalizerTests(TestCase):

    def setUp(self):
        self.osReader = OpSpamReader()
        self.readReviews = self.osReader.ReadAllFiles()
        self.dimensionalizer = BigramPlusDimensionalizer(self.readReviews)

    def test_getbigramsplus_returns_proper_set_file_1(self):
        # Arrange
        expectedSetResult = 195

        # Act
        returnedSet = self.dimensionalizer.featureGetter(self.readReviews[0])

        # Assert
        self.assertEqual(len(returnedSet), expectedSetResult)

    def test_bigramplus_file_1_correctly(self):
        # Arrange
        expectedSetResult = 195

        # Act
        self.dimensionalizer.__DimensionalizeReview__(self.readReviews[0])

        # Assert
        self.assertEqual(len(self.dimensionalizer.dimensionSet), expectedSetResult)

    def test_bigramplus_file_82_correctly(self):
        # Arrange
        expectedSetResult = 180

        # Act
        self.dimensionalizer.__DimensionalizeReview__(self.readReviews[82])

        # Assert
        self.assertEqual(len(self.dimensionalizer.dimensionSet), expectedSetResult)

    def test_bigramplus_file_1_and_82_combined_correctly(self):
        # Arrange
        expectedTwoSetsResult = 363

        # Act
        self.dimensionalizer.__DimensionalizeReview__(self.readReviews[0])
        self.dimensionalizer.__DimensionalizeReview__(self.readReviews[82])

        # Assert
        self.assertEqual(len(self.dimensionalizer.dimensionSet), expectedTwoSetsResult)

    def test_bigramplusALL_with_2_files(self):
        # Arrange
        expectedSetResult = 363
        reviewList = []
        reviewList.append(self.readReviews[0])
        reviewList.append(self.readReviews[82])

        # Act
        self.dimensionalizer.__DimensionalizeAllReviews__(reviewList=reviewList)

        # Assert
        self.assertEqual(len(self.dimensionalizer.dimensionSet), expectedSetResult)

    def test_CreateDictionary_for_files_1_and_82_has_right_amount(self):
        # Arrange
        expectedNumberOfKeys = 363

        # Act
        self.dimensionalizer.__DimensionalizeReview__(self.readReviews[0])
        self.dimensionalizer.__DimensionalizeReview__(self.readReviews[82])
        self.dimensionalizer.CreateDictionaryOfWords()

        # Assert
        self.assertEqual(len(self.dimensionalizer.mappingDictionary.keys()), expectedNumberOfKeys)

    def test_CreateDictionary_deletes_old_dictionary(self):
        # Arrange
        expectedNumberOfKeys = 195

        # Act
        self.dimensionalizer.__DimensionalizeReview__(self.readReviews[0])
        self.dimensionalizer.CreateDictionaryOfWords()

        # Assert
        self.assertEqual(len(self.dimensionalizer.mappingDictionary.keys()), expectedNumberOfKeys)

        # Re-arrange
        self.dimensionalizer.dimensionSet = set()  # Delete the current dimensionset
        expectedNumberOfKeysAfterNewCreation = 180

        # Re-act
        self.dimensionalizer.__DimensionalizeReview__(self.readReviews[82])
        self.dimensionalizer.CreateDictionaryOfWords()

        # Re-assert
        self.assertEqual(len(self.dimensionalizer.mappingDictionary.keys()), expectedNumberOfKeysAfterNewCreation)

    def test_dictionary_maps_words_to_integers(self):
        # Arrange
        index = None

        # Act
        self.dimensionalizer.__DimensionalizeReview__(self.readReviews[0])
        self.dimensionalizer.CreateDictionaryOfWords()
        index = self.dimensionalizer.mappingDictionary["hilton"]  # Word from the first review

        # Assert
        self.assertTrue(type(index) is int)

    def test_CreateVector_for_review_1(self):
        # Arrange
        featureCount = 96045  # Number of bigramsPlus in dataset
        expectedVectorOnesCount = 195  # Number of 1-entries in generated vector
        actualVectorOnesCount = 0

        # Act
        self.dimensionalizer.__DimensionalizeAllReviews__(self.readReviews)
        vector = self.dimensionalizer.CreateVectorForReview(self.readReviews[0])
        for entry in vector[0]:
            if entry == 1:
                actualVectorOnesCount += 1

        # Assert
        self.assertEqual(len(vector[0]), featureCount)
        self.assertEqual(actualVectorOnesCount, expectedVectorOnesCount)


class TrigramDimensionalizerTests(TestCase):

    def setUp(self):
        self.osReader = OpSpamReader()
        self.readReviews = self.osReader.ReadAllFiles()
        self.dimensionalizer = TrigramDimensionalizer(self.readReviews)

    def test_get_trigrams_returns_proper_set_file_1(self):
        # Arrange
        expectedSetResult = 118

        # Act
        returnedSet = self.dimensionalizer.featureGetter(self.readReviews[0])

        # Assert
        self.assertEqual(len(returnedSet), expectedSetResult)

    def test_trigram_file_1_correctly(self):
        # Arrange
        expectedSetResult = 118

        # Act
        self.dimensionalizer.__DimensionalizeReview__(self.readReviews[0])

        # Assert
        self.assertEqual(len(self.dimensionalizer.dimensionSet), expectedSetResult)

    def test_trigram_file_82_correctly(self):
        # Arrange
        expectedSetResult = 105

        # Act
        self.dimensionalizer.__DimensionalizeReview__(self.readReviews[82])

        # Assert
        self.assertEqual(len(self.dimensionalizer.dimensionSet), expectedSetResult)

    def test_trigram_file_1_and_82_combined_correctly(self):
        # Arrange
        expectedTwoSetsResult = 223

        # Act
        self.dimensionalizer.__DimensionalizeReview__(self.readReviews[0])
        self.dimensionalizer.__DimensionalizeReview__(self.readReviews[82])

        # Assert
        self.assertEqual(len(self.dimensionalizer.dimensionSet), expectedTwoSetsResult)

    def test_trigramALL_with_2_files(self):
        # Arrange
        expectedSetResult = 223
        reviewList = []
        reviewList.append(self.readReviews[0])
        reviewList.append(self.readReviews[82])

        # Act
        self.dimensionalizer.__DimensionalizeAllReviews__(reviewList=reviewList)

        # Assert
        self.assertEqual(len(self.dimensionalizer.dimensionSet), expectedSetResult)

    def test_CreateDictionary_for_files_1_and_82_has_right_amount(self):
        # Arrange
        expectedNumberOfKeys = 223

        # Act
        self.dimensionalizer.__DimensionalizeReview__(self.readReviews[0])
        self.dimensionalizer.__DimensionalizeReview__(self.readReviews[82])
        self.dimensionalizer.CreateDictionaryOfWords()

        # Assert
        self.assertEqual(len(self.dimensionalizer.mappingDictionary.keys()), expectedNumberOfKeys)

    def test_CreateDictionary_deletes_old_dictionary(self):
        # Arrange
        expectedNumberOfKeys = 118

        # Act
        self.dimensionalizer.__DimensionalizeReview__(self.readReviews[0])
        self.dimensionalizer.CreateDictionaryOfWords()

        # Assert
        self.assertEqual(len(self.dimensionalizer.mappingDictionary.keys()), expectedNumberOfKeys)

        # Re-arrange
        self.dimensionalizer.dimensionSet = set()  # Delete the current dimensionset
        expectedNumberOfKeysAfterNewCreation = 105

        # Re-act
        self.dimensionalizer.__DimensionalizeReview__(self.readReviews[82])
        self.dimensionalizer.CreateDictionaryOfWords()

        # Re-assert
        self.assertEqual(len(self.dimensionalizer.mappingDictionary.keys()), expectedNumberOfKeysAfterNewCreation)

    def test_dictionary_maps_words_to_integers(self):
        # Arrange
        index = None

        # Act
        self.dimensionalizer.__DimensionalizeReview__(self.readReviews[0])
        self.dimensionalizer.CreateDictionaryOfWords()
        index = self.dimensionalizer.mappingDictionary["ordered some pizzas"]  # Word from the first review

        # Assert
        self.assertTrue(type(index) is int)

    def test_CreateVector_for_review_1(self):
        # Arrange
        featureCount = 168004  # Number of trigrams in dataset
        expectedVectorOnesCount = 118  # Number of 1-entries in generated vector
        actualVectorOnesCount = 0

        # Act
        self.dimensionalizer.__DimensionalizeAllReviews__(self.readReviews)
        vector = self.dimensionalizer.CreateVectorForReview(self.readReviews[0])
        for entry in vector[0]:
            if entry == 1:
                actualVectorOnesCount += 1

        # Assert
        self.assertEqual(len(vector[0]), featureCount)
        self.assertEqual(actualVectorOnesCount, expectedVectorOnesCount)


class TrigramPlusDimensionalizerTests(TestCase):

    def setUp(self):
        self.osReader = OpSpamReader()
        self.readReviews = self.osReader.ReadAllFiles()
        self.dimensionalizer = TrigramPlusDimensionalizer(self.readReviews)

    def test_get_trigramsplus_returns_proper_set_file_1(self):
        # Arrange
        expectedSetResult = 313

        # Act
        returnedSet = self.dimensionalizer.featureGetter(self.readReviews[0])

        # Assert
        self.assertEqual(len(returnedSet), expectedSetResult)

    def test_trigramplus_file_1_correctly(self):
        # Arrange
        expectedSetResult = 313

        # Act
        self.dimensionalizer.__DimensionalizeReview__(self.readReviews[0])

        # Assert
        self.assertEqual(len(self.dimensionalizer.dimensionSet), expectedSetResult)

    def test_trigramplus_file_82_correctly(self):
        # Arrange
        expectedSetResult = 285

        # Act
        self.dimensionalizer.__DimensionalizeReview__(self.readReviews[82])

        # Assert
        self.assertEqual(len(self.dimensionalizer.dimensionSet), expectedSetResult)

    def test_trigramplus_file_1_and_82_combined_correctly(self):
        # Arrange
        expectedTwoSetsResult = 586

        # Act
        self.dimensionalizer.__DimensionalizeReview__(self.readReviews[0])
        self.dimensionalizer.__DimensionalizeReview__(self.readReviews[82])

        # Assert
        self.assertEqual(len(self.dimensionalizer.dimensionSet), expectedTwoSetsResult)

    def test_trigramplusALL_with_2_files(self):
        # Arrange
        expectedSetResult = 586
        reviewList = []
        reviewList.append(self.readReviews[0])
        reviewList.append(self.readReviews[82])

        # Act
        self.dimensionalizer.__DimensionalizeAllReviews__(reviewList=reviewList)

        # Assert
        self.assertEqual(len(self.dimensionalizer.dimensionSet), expectedSetResult)

    def test_CreateDictionary_for_files_1_and_82_has_right_amount(self):
        # Arrange
        expectedNumberOfKeys = 586

        # Act
        self.dimensionalizer.__DimensionalizeReview__(self.readReviews[0])
        self.dimensionalizer.__DimensionalizeReview__(self.readReviews[82])
        self.dimensionalizer.CreateDictionaryOfWords()

        # Assert
        self.assertEqual(len(self.dimensionalizer.mappingDictionary.keys()), expectedNumberOfKeys)

    def test_CreateDictionary_deletes_old_dictionary(self):
        # Arrange
        expectedNumberOfKeys = 313

        # Act
        self.dimensionalizer.__DimensionalizeReview__(self.readReviews[0])
        self.dimensionalizer.CreateDictionaryOfWords()

        # Assert
        self.assertEqual(len(self.dimensionalizer.mappingDictionary.keys()), expectedNumberOfKeys)

        # Re-arrange
        self.dimensionalizer.dimensionSet = set()  # Delete the current dimensionset
        expectedNumberOfKeysAfterNewCreation = 285

        # Re-act
        self.dimensionalizer.__DimensionalizeReview__(self.readReviews[82])
        self.dimensionalizer.CreateDictionaryOfWords()

        # Re-assert
        self.assertEqual(len(self.dimensionalizer.mappingDictionary.keys()), expectedNumberOfKeysAfterNewCreation)

    def test_dictionary_maps_words_to_integers(self):
        # Arrange
        index = None

        # Act
        self.dimensionalizer.__DimensionalizeReview__(self.readReviews[0])
        self.dimensionalizer.CreateDictionaryOfWords()
        index = self.dimensionalizer.mappingDictionary["hilton"]  # Word from the first review

        # Assert
        self.assertTrue(type(index) is int)

    def test_CreateVector_for_review_1(self):
        # Arrange
        featureCount = 264049  # Number of trigramsplus in dataset
        expectedVectorOnesCount = 313  # Number of 1-entries in generated vector
        actualVectorOnesCount = 0

        # Act
        self.dimensionalizer.__DimensionalizeAllReviews__(self.readReviews)
        vector = self.dimensionalizer.CreateVectorForReview(self.readReviews[0])
        for entry in vector[0]:
            if entry == 1:
                actualVectorOnesCount += 1

        # Assert
        self.assertEqual(len(vector[0]), featureCount)
        self.assertEqual(actualVectorOnesCount, expectedVectorOnesCount)


def validateDimensionalizerSetSize(testClassInstance, DimensionalizerClass, reviewList, expectedSetResult):
    # Act
    dimensionalizer = DimensionalizerClass(reviewList)

    # Assert
    testClassInstance.assertEqual(len(dimensionalizer.dimensionSet), expectedSetResult)
