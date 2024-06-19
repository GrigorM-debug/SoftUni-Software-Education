const { body } = require('express-validator');

const movieValidation = [
    body('title')
        .trim()
        .notEmpty()
        .withMessage('Title is required!')
        .isLength({ min: 5 })
        .withMessage('Title must be at least 5 characters long!')
        .matches(/^[A-Za-z0-9\s]+$/)
        .withMessage('Title must contain only English letters, digits, and whitespaces.'),

    body('genre')
        .trim()
        .notEmpty()
        .withMessage('Genre is required!')
        .isLength({ min: 5 })
        .withMessage('Genre must be at least 5 characters long!')
        .matches(/^[A-Za-z0-9\s]+$/)
        .withMessage('Genre must contain only English letters, digits, and whitespaces.'),

    body('director')
        .trim()
        .notEmpty()
        .withMessage('Director is required!')
        .isLength({ min: 5 })
        .withMessage('Director must be at least 5 characters long!')
        .matches(/^[A-Za-z0-9\s]+$/)
        .withMessage('Director must contain only English letters, digits, and whitespaces.'),

    body('year')
        .trim()
        .notEmpty()
        .withMessage('Year is required!')
        .isInt({ min: 1900, max: 2024 })
        .withMessage('Year must be between 1900 and 2024!'),

    body('imageURL')
        .trim()
        .notEmpty()
        .withMessage('Image URL is required!')
        .matches(/^(http|https):\/\/[^ "]+$/)
        .withMessage('Image URL must be a valid URL!'),

    body('rating')
        .trim()
        .notEmpty()
        .withMessage('Rating is required!')
        .isInt({ min: 1, max: 5 })
        .withMessage('Rating must be between 1 and 5!'),

    body('description')
        .trim()
        .notEmpty()
        .withMessage('Description is required!')
        .isLength({ min: 20 })
        .withMessage('Description must be at least 20 characters long!')
        .matches(/^[A-Za-z0-9\s]+$/)
        .withMessage('Description must contain only English letters, digits, and whitespaces.'),
];

module.exports = { movieValidation };
