const {body} = require('express-validator');

const volcanoValidations = [
    body('name')
        .trim()
        .notEmpty()
        .withMessage('Name is required !'),

    body('name')
        .trim()
        .isLength({min: 2})
        .withMessage('Name must be at least 2 characters long !'),

    body('location')
        .trim()
        .notEmpty()
        .withMessage('Location is required !'),
    
    body('location')
        .trim()
        .isLength({min: 3})
        .withMessage('Location must be at least 3 characters long !'),

    body('elevation')
        .trim()
        .notEmpty()
        .withMessage('Elevation is required !'),

    body('elevation')
        .trim()
        .isLength({min: 0})
        .withMessage('Elevation must be at least 0 !'),

    body('lastEruption')
        .trim()
        .notEmpty()
        .withMessage('Year of Last Eruption is required !'),

    body('lastEruption')
        .trim()
        .isLength({min: 0, max: 2024})
        .withMessage("Year of Last Eruption must at least 0 and max 2024!"),

    body('image')
        .trim()
        .notEmpty()
        .withMessage('Image is required !'),

    body('image')
        .trim()
        .isURL()
        .withMessage('Invalid image URL!'),

    body('type')
        .trim()
        .notEmpty()
        .withMessage('Volcano type is required !'),

    body('type')
        .trim()
        .isIn(["Supervolcanoes", "Submarine", "Subglacial", "Mud", "Stratovolcanoes", "Shield"])
        .withMessage('The type is not supported for the volcano type.'),

    body('description')
        .trim()
        .notEmpty()
        .withMessage('Description is required !'),
    
    body('description')
        .trim()
        .isLength({min: 10})
        .withMessage('Description must at least 10 characters long !'),

    
]

module.exports = {volcanoValidations};