from unittest import TestCase
from OpinionSpamPackage import DvaNaiveBayesClassifier, OpSpamReader, ClassifierResult


class DvaNaiveBayesClassifierTests(TestCase):

    def setUp(self):
        self.osReader = OpSpamReader()
        self.allReviews = self.osReader.ReadAllFiles()
        self.naiveBayesClassifier = DvaNaiveBayesClassifier(reviewList=self.allReviews)

    def test_is_model_learned(self):
        # Arrange

        # Act
        self.naiveBayesClassifier.LearnModelForAllReviews()

        # Assert
        self.assertTrue(self.naiveBayesClassifier.model is not None)

    def test_returns_valid_classifierResult(self):
        # Arrange

        # Act
        classifierResult = self.naiveBayesClassifier.Do5FoldValidation()

        # Assert
        self.assertTrue(type(classifierResult) is ClassifierResult)
        self.assertTrue(0 <= classifierResult.precision <= 1)

    def test_returns_expected_result_on_unigram(self):
        # Arrange
        expectedResult = 0.65

        # Act
        classifierResult = self.naiveBayesClassifier.Do5FoldValidation()

        # Assert
        self.assertEqual(expectedResult, classifierResult.precision)