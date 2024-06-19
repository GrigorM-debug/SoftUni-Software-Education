const {body} = require('express-validator');

const userValidations = [
    body('email')
        .trim()
        .notEmpty()
        .withMessage('Email is required!'),
    body('email')
        .trim()
        .isEmail()
        .withMessage('Invalid email!'),
    body('email')
        .trim()
        .isLength({ min: 10 })
        .withMessage('Email must be at least 10 characters long!'),
    
    body('password')
        .trim()
        .notEmpty()
        .withMessage('Password is required!'),
    body('password')
        .trim()
        .isLength({ min: 6 })
        .withMessage('Password must be at least 6 characters long!')
];

module.exports = {userValidations};