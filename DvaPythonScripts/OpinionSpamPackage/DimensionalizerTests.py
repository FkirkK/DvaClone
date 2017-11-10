from unittest import TestCase
from OpinionSpamPackage import OpSpamReader
from OpinionSpamPackage import UniGramDimensionalizer
from OpinionSpamPackage import BigramDimensionalizer
from OpinionSpamPackage import BigramPlusDimensionalizer
from OpinionSpamPackage import TrigramDimensionalizer
from OpinionSpamPackage import TrigramPlusDimensionalizer


class UnigramDimensionalizerTests(TestCase):

    @classmethod
    def setUpClass(cls):
        cls.osReader = OpSpamReader()
        cls.readReviews = cls.osReader.ReadAllFiles()

    def test_getunigrams_returns_proper_set_file_1(self):
        validateLengthOfFeature(self, UniGramDimensionalizer, expectedSetResult=82)

    def test_unigram_file_1_correctly(self):
        validateDimensionalizerSetSize(self, UniGramDimensionalizer, [self.readReviews[0]], expectedSetResult=82)

    def test_unigram_file_82_correctly(self):
        validateDimensionalizerSetSize(self, UniGramDimensionalizer, [self.readReviews[82]], expectedSetResult=79)

    def test_unigram_file_1_and_82_combined_correctly(self):
        validateDimensionalizerSetSize(self, UniGramDimensionalizer, [self.readReviews[0], self.readReviews[82]], expectedSetResult=150)

    def test_CreateDictionary_for_files_1_and_82_has_right_amount(self):
        validateNumberOfKeysInMappingdictionary(self, UniGramDimensionalizer, [self.readReviews[0], self.readReviews[82]], expectedNumberOfKeys=150)

    def test_dictionary_maps_words_to_integers(self):
        validateMappingOfWords(self, UniGramDimensionalizer, [self.readReviews[0]], "hilton")

    def test_CreateVector_for_review_1(self):
        validateVectorSizeReview(self, UniGramDimensionalizer, featureCount=11933, expectedVectorOnesCount=82)


class BigramDimensionalizerTests(TestCase):

    @classmethod
    def setUpClass(cls):
        cls.osReader = OpSpamReader()
        cls.readReviews = cls.osReader.ReadAllFiles()

    def test_getbigrams_returns_proper_set_file_1(self):
        validateLengthOfFeature(self, BigramDimensionalizer, expectedSetResult=113)

    def test_bigram_file_1_correctly(self):
        validateDimensionalizerSetSize(self, BigramDimensionalizer, [self.readReviews[0]], expectedSetResult=113)

    def test_bigram_file_82_correctly(self):
        validateDimensionalizerSetSize(self, BigramDimensionalizer, [self.readReviews[82]], expectedSetResult=101)

    def test_bigram_file_1_and_82_combined_correctly(self):
        validateDimensionalizerSetSize(self, BigramDimensionalizer, [self.readReviews[0], self.readReviews[82]], expectedSetResult=213)

    def test_CreateDictionary_for_files_1_and_82_has_right_amount(self):
        validateNumberOfKeysInMappingdictionary(self, BigramDimensionalizer, [self.readReviews[0], self.readReviews[82]], expectedNumberOfKeys=213)

    def test_dictionary_maps_words_to_integers(self):
        validateMappingOfWords(self, BigramDimensionalizer, [self.readReviews[0]], "some pizzas")

    def test_CreateVector_for_review_1(self):
        validateVectorSizeReview(self, BigramDimensionalizer, featureCount=84112, expectedVectorOnesCount=113)


class BigramPlusDimensionalizerTests(TestCase):

    @classmethod
    def setUpClass(cls):
        cls.osReader = OpSpamReader()
        cls.readReviews = cls.osReader.ReadAllFiles()

    def test_getbigramsplus_returns_proper_set_file_1(self):
        validateLengthOfFeature(self, BigramPlusDimensionalizer, expectedSetResult=195)

    def test_bigramplus_file_1_correctly(self):
        validateDimensionalizerSetSize(self, BigramPlusDimensionalizer, [self.readReviews[0]], expectedSetResult=195)

    def test_bigramplus_file_82_correctly(self):
        validateDimensionalizerSetSize(self, BigramPlusDimensionalizer, [self.readReviews[82]], expectedSetResult=180)

    def test_bigramplus_file_1_and_82_combined_correctly(self):
        validateDimensionalizerSetSize(self, BigramPlusDimensionalizer, [self.readReviews[0], self.readReviews[82]], expectedSetResult=363)

    def test_CreateDictionary_for_files_1_and_82_has_right_amount(self):
        validateNumberOfKeysInMappingdictionary(self, BigramPlusDimensionalizer, [self.readReviews[0], self.readReviews[82]], expectedNumberOfKeys=363)

    def test_dictionary_maps_words_to_integers(self):
        validateMappingOfWords(self, BigramPlusDimensionalizer, [self.readReviews[0]], "hilton")

    def test_CreateVector_for_review_1(self):
        validateVectorSizeReview(self, BigramPlusDimensionalizer, featureCount=96045, expectedVectorOnesCount=195)


class TrigramDimensionalizerTests(TestCase):

    @classmethod
    def setUpClass(cls):
        cls.osReader = OpSpamReader()
        cls.readReviews = cls.osReader.ReadAllFiles()

    def test_get_trigrams_returns_proper_set_file_1(self):
        validateLengthOfFeature(self, TrigramDimensionalizer, expectedSetResult=118)

    def test_trigram_file_1_correctly(self):
        validateDimensionalizerSetSize(self, TrigramDimensionalizer, [self.readReviews[0]], expectedSetResult=118)

    def test_trigram_file_82_correctly(self):
        validateDimensionalizerSetSize(self, TrigramDimensionalizer, [self.readReviews[82]], expectedSetResult=105)

    def test_trigram_file_1_and_82_combined_correctly(self):
        validateDimensionalizerSetSize(self, TrigramDimensionalizer, [self.readReviews[0], self.readReviews[82]], expectedSetResult=223)

    def test_CreateDictionary_for_files_1_and_82_has_right_amount(self):
        validateNumberOfKeysInMappingdictionary(self, TrigramDimensionalizer, [self.readReviews[0], self.readReviews[82]], expectedNumberOfKeys=223)

    def test_dictionary_maps_words_to_integers(self):
        validateMappingOfWords(self, TrigramDimensionalizer, [self.readReviews[0]], "ordered some pizzas")

    def test_CreateVector_for_review_1(self):
        validateVectorSizeReview(self, TrigramDimensionalizer, featureCount=168004, expectedVectorOnesCount=118)


class TrigramPlusDimensionalizerTests(TestCase):

    @classmethod
    def setUpClass(cls):
        cls.osReader = OpSpamReader()
        cls.readReviews = cls.osReader.ReadAllFiles()

    def test_get_trigramsplus_returns_proper_set_file_1(self):
        validateLengthOfFeature(self, TrigramPlusDimensionalizer, expectedSetResult=313)

    def test_trigramplus_file_1_correctly(self):
        validateDimensionalizerSetSize(self, TrigramPlusDimensionalizer, [self.readReviews[0]], expectedSetResult=313)

    def test_trigramplus_file_82_correctly(self):
        validateDimensionalizerSetSize(self, TrigramPlusDimensionalizer, [self.readReviews[82]], expectedSetResult=285)

    def test_trigramplus_file_1_and_82_combined_correctly(self):
        validateDimensionalizerSetSize(self, TrigramPlusDimensionalizer, [self.readReviews[0], self.readReviews[82]], expectedSetResult=586)

    def test_CreateDictionary_for_files_1_and_82_has_right_amount(self):
        validateNumberOfKeysInMappingdictionary(self, TrigramPlusDimensionalizer, [self.readReviews[0], self.readReviews[82]], expectedNumberOfKeys=586)

    def test_dictionary_maps_words_to_integers(self):
        validateMappingOfWords(self, TrigramPlusDimensionalizer, [self.readReviews[0]], "hilton")

    def test_CreateVector_for_review_1(self):
        validateVectorSizeReview(self, TrigramPlusDimensionalizer, featureCount=264049, expectedVectorOnesCount=313)


def validateLengthOfFeature(testClassInstance, Dimensionalizer, expectedSetResult):
    # Arrange
    dimensionalizer = Dimensionalizer(testClassInstance.readReviews)

    # Act
    returnedSet = dimensionalizer.featureGetter(testClassInstance.readReviews[0])

    # Assert
    testClassInstance.assertEqual(len(returnedSet), expectedSetResult)


def validateDimensionalizerSetSize(testClassInstance, DimensionalizerClass, reviewList, expectedSetResult):
    # Act
    dimensionalizer = DimensionalizerClass(reviewList)

    # Assert
    testClassInstance.assertEqual(len(dimensionalizer.dimensionSet), expectedSetResult)


def validateNumberOfKeysInMappingdictionary(testClassInstance, Dimensionalizer, reviewList, expectedNumberOfKeys):
    # Arrange
    dimensionalizer = Dimensionalizer(reviewList)

    # Assert
    testClassInstance.assertEqual(len(dimensionalizer.mappingDictionary.keys()), expectedNumberOfKeys)


def validateMappingOfWords(testClassInstance, Dimensionalizer, reviewList, wordToTest):
    # Arrange
    dimensionalizer = Dimensionalizer(reviewList)

    # Act
    index = dimensionalizer.mappingDictionary[wordToTest]  # Word from the first review

    # Assert
    testClassInstance.assertTrue(index is not None)


# FeatureCount is the number of n-grams in dataset
# ExpectedVectorOnesCount is the number of 1-entries in generated vector
def validateVectorSizeReview(testClassInstance, Dimensionalizer, featureCount, expectedVectorOnesCount):
    # Arrange
    actualVectorOnesCount = 0
    dimensionalizer = Dimensionalizer(testClassInstance.readReviews)

    # Act
    vector = dimensionalizer.GetFeatureSet([0])
    for entry in vector[0]:
        if entry == 1:
            actualVectorOnesCount += 1

    # Assert
    testClassInstance.assertEqual(len(vector[0]), featureCount)
    testClassInstance.assertEqual(actualVectorOnesCount, expectedVectorOnesCount)
