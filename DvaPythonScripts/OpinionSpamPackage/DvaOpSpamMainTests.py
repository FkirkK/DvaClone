from unittest import TestCase
from OpinionSpamPackage import OpSpamReader
from OpinionSpamPackage import DvaLinearSvm
from sklearn import svm


class DvaOpSpamMainTests(TestCase):

    def setUp(self):
        self.osReader = OpSpamReader()
        self.allReviews = self.osReader.ReadAllFiles()
        self.dvaLinearSVM = DvaLinearSvm(self.allReviews)

    def test_instantiates_with_right_amount_of_reviews(self):
        # Arrange
        expectedAmount = 1600

        # Act
        # Handled by setUp()

        # Assert
        self.assertEqual(len(self.dvaLinearSVM.reviewList), expectedAmount)

    def test_is_a_model_learned(self):
        # Arrange
        expectedValue = True

        # Act
        self.dvaLinearSVM.LearnModelForAllReviews()

        # Assert
        self.assertEqual(type(self.dvaLinearSVM.model) is svm.LinearSVC, expectedValue)

    def test_can_model_predict_own_member_correctly(self):
        # Arrange
        expectedValue = True

        # Act
        self.dvaLinearSVM.LearnModelForAllReviews()
        vectorToPredict = self.dvaLinearSVM.dimensionalizer.GetFeatureSet([0])
        prediction = self.dvaLinearSVM.model.predict(vectorToPredict)

        # Assert
        self.assertEqual(prediction, expectedValue)

    def test_5_fold_validation_matches_paper_89point6_percent(self):
        # Arrange
        expectedValue = 0.896

        # Act
        result = self.dvaLinearSVM.Do5FoldValidation()
        actualValue = (result.trueTruthful + result.trueDeceitful) / 1600

        # Assert
        self.assertAlmostEqual(expectedValue, actualValue, delta=0.05)
