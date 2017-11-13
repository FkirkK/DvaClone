from unittest import TestCase
from gensim.models import doc2vec
from collections import namedtuple

from gensim.models.doc2vec import TaggedDocument


class ParagraphDimensionalizerTests(TestCase):

    def test_can_make_paragraph_vectors(self):
        # Arrange
        docCollection = ["This is a sentence wut wut wut wut wut alalala", "This is another sentence", "The third confused sentence"]
        docs = []
        tags = [1]

        # Act
        tags[0] = 0
        docs.append(TaggedDocument(docCollection[0].split(), tags=tags))  # Tags must be iterable - tag given for each word in document
        tags[0] = 1
        docs.append(TaggedDocument(docCollection[1].split(), tags=tags))
        tags[0] = 2
        docs.append(TaggedDocument(docCollection[2].split(), tags=tags))

        model = doc2vec.Doc2Vec(docs, size=5, window=300, min_count=1, workers=4)

        # Assert
        self.assertEqual(5, len(model.docvecs[0]))
        self.assertEqual(5, len(model.docvecs[1]))
        self.assertEqual(5, len(model.docvecs[2]))
        self.assertEqual(3, len(model.docvecs))

