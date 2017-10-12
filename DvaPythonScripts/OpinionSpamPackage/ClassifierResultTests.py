from unittest import TestCase
from OpinionSpamPackage import ClassifierResult


class ClassifierResultTests(TestCase):

    def setUp(self):
        self.resultList = []
        self.resultList.append(ClassifierResult(fold=1, precision=80.0, fakePositives=11.0, fakeNegatives=11.0, reviewList=[]))
        self.resultList.append(ClassifierResult(fold=2, precision=90.0, fakePositives=13.0, fakeNegatives=5.0, reviewList=[]))
        self.resultList.append(ClassifierResult(fold=3, precision=83.0, fakePositives=9.0, fakeNegatives=10.0, reviewList=[]))
        self.resultList.append(ClassifierResult(fold=4, precision=87.0, fakePositives=15.0, fakeNegatives=6.0, reviewList=[]))
        self.resultList.append(ClassifierResult(fold=5, precision=85.0, fakePositives=12.0, fakeNegatives=8.0, reviewList=[]))
        self.aggregatedResult = ClassifierResult.AggregateResults(self.resultList)

    def test_aggregate_returns_new_classifierResult(self):
        # Arrange
        expectedValue = True

        # Act

        # Assert
        self.assertEqual(type(self.aggregatedResult) is ClassifierResult, expectedValue)

    def test_aggregates_precision_correctly(self):
        # Arrange
        expectedPrecision = 85.0

        # Act

        # Assert
        self.assertAlmostEqual(self.aggregatedResult.precision, expectedPrecision, delta=0.001)

    def test_aggregates_fake_positives_correctly(self):
        # Arrange
        expectedFakePositiveResult = 12

        # Act

        # Assert
        self.assertAlmostEqual(self.aggregatedResult.fakePositives, expectedFakePositiveResult, delta=0.001)

    def test_aggregates_fake_negatives_correctly(self):
        # Arrange
        expectedFakeNegativeResult = 8

        # Act

        # Assert
        self.assertAlmostEqual(self.aggregatedResult.fakeNegatives, expectedFakeNegativeResult, delta=0.001)

    def test_aggregate_assigns_correct_worst_fold(self):
        # Arrange
        expectedFNFold = 1
        expectedFPFold = 4
        expectedPrecisionFold = 1

        # Act

        # Assert
        self.assertEqual(self.aggregatedResult.fakeNegativesWorstFold, expectedFNFold)
        self.assertEqual(self.aggregatedResult.fakePositivesWorstFold, expectedFPFold)
        self.assertEqual(self.aggregatedResult.precisionWorstFold, expectedPrecisionFold)

    def test_aggregate_assigns_correct_best_fold(self):
        # Arrange
        expectedFNFold = 2
        expectedFPFold = 3
        expectedPrecisionFold = 2

        # Act

        # Assert
        self.assertEqual(self.aggregatedResult.fakeNegativesBestFold, expectedFNFold)
        self.assertEqual(self.aggregatedResult.fakePositivesBestFold, expectedFPFold)
        self.assertEqual(self.aggregatedResult.precisionBestFold, expectedPrecisionFold)

    def test_print_has_correct_amount_of_fields(self):
        # Arrange
        expectedFieldCount = 9

        # Act
        string = self.aggregatedResult.__str__()
        actualFieldCount = len(string.split(","))

        # Assert
        self.assertEqual(expectedFieldCount, actualFieldCount)

    def test_print_has_correct_amount_of_fields_with_reviews(self):
        # Arrange
        expectedFieldCount = 15
        self.aggregatedResult.reviews.append(("t_hilton_1.txt", True, False))
        self.aggregatedResult.reviews.append(("t_hilton_5.txt", True, True))

        # Act
        string = self.aggregatedResult.__str__()
        actualFieldCount = len(string.split(","))

        # Assert
        self.assertEqual(expectedFieldCount, actualFieldCount)

    def test_prints_reviews_correctly(self):
        # Arrange
        expectedField9String = " t_hilton_1.txt"
        expectedField10String = " 1"
        expectedField11String = " 0"
        expectedField12String = " t_hilton_5.txt"
        expectedField13String = " 1"
        expectedField14String = " 1"
        self.aggregatedResult.reviews.append(("t_hilton_1.txt", True, False))
        self.aggregatedResult.reviews.append(("t_hilton_5.txt", True, True))

        # Act
        string = self.aggregatedResult.__str__()
        splitFields = string.split(",")

        # Assert
        self.assertEqual(expectedField9String, splitFields[9])
        self.assertEqual(expectedField10String, splitFields[10])
        self.assertEqual(expectedField11String, splitFields[11])
        self.assertEqual(expectedField12String, splitFields[12])
        self.assertEqual(expectedField13String, splitFields[13])
        self.assertEqual(expectedField14String, splitFields[14])

