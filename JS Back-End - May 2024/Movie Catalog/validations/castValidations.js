const { body } = require('express-validator');

const castValidation = [
    body('name')
        .trim()
        .notEmpty()
        .withMessage('Name is required!'),
    body('name')
        .trim()
        .isLength({ min: 5 })
        .withMessage('Name must be at least 5 characters long!'),
    body('name')
        .trim()
        .matches(/^[A-Za-z0-9\s]+$/)
        .withMessage('Name must contain only English letters, digits, and whitespaces.'),
    
    body('age')
        .trim()
        .notEmpty()
        .withMessage('Age is required!'),
    body('age')
        .trim()
        .isInt({ min: 1, max: 120 })
        .withMessage('Age must be between 1 and 120!'),
    
    body('born')
        .trim()
        .notEmpty()
        .withMessage('Born is required!'),
    body('born')
        .trim()
        .isLength({ min: 10 })
        .withMessage('Born must be at least 10 characters long!'),
    body('born')
        .trim()
        .matches(/^[a-zA-Z0-9\s]+$/)
        .withMessage('Born must contain only English letters, digits, and whitespaces.'),

    body('nameInMovie')
        .trim()
        .notEmpty()
        .withMessage('Name in movie is required!'),
    body('nameInMovie')
        .trim()
        .isLength({ min: 5 })
        .withMessage('Name in movie must be at least 5 characters long!'),
    body('nameInMovie')
        .trim()
        .matches(/^[A-Za-z0-9\s]+$/)
        .withMessage('Name in movie must contain only English letters, digits, and whitespaces.'),
    
    body('castImage')
        .trim()
        .notEmpty()
        .withMessage('Cast image is required!'),
    body('castImage')
        .trim()
        .matches(/^(http|https):\/\/[^ "]+$/)
        .withMessage('Cast image must be a valid URL!'),       
];

module.exports = { castValidation };