# Gym App Spec:

## Home Page:

3 Main Functions - Navigation
- Display Members Page
- Display Trainers Page
- Display About Page

___
## Members Page:

Functionality includes:
- CRUD for members
- Display the "Weigh In" page as the "Member Stats" Button - **can use a modal to achieve this**
___

## Weigh In Page:

3 Functions:

- Calculate BMI:
    - Opens new Form that hold the following properties
        - Gender
        - Age
        - Weight
        - Height
    - Calculate BMI Button:
        - Opens new form and Calculates BMI based on given properties
        - Displays Results in Current Page
    - Calulations are as Follows:   
        - Male & Female Actual: ``` Weight / (Height / 100)^2```
        - Male Optimal: ```(0.5 * Weight) / ((Height / 100)^2) + 11.5```
        - Female Optimal: ```(0.5 * Weight) / ((Height / 100)^2) + (0.03 * Age) + 11```
    - BMI statuses: 
        - BMI > 31 -> Obese
        - BMI >= 26 -> Overweight
        - BMI >= 18.5 -> Normal
        - BMI < 18.4 -> Underweight

- Calculate HRmax & VO2max:
    - Functionality:
        - Gets the **HRrest** then calculates the above 2
        - Then result is displayed in the fields on the tabbed pane
    - Calculations are as Follows:
        - Calculate HRmax: ```205.8 - (0.685 * Age)```
        - Calculate VO2max: ```15 * (HRmax / HRrest)```

- Done Button:
    - Saves the 2 calculations from above into the DB
___

## Trainers Page:

Functionality Includes:   
- CRUD for trainers - D(Delete) = Fire as in Firing an employee
- Calculates Salary for Trainer
- Shows a list of Members under the Trainers - can use **master-detail** functionality of DevExtreme to achieve this

Fields for Trainers are as Follows:
- ID number
- Name
- Surnam
- Contact Number
- Class(class of trainer) - A, B, C

Calculation of Salary is as Follows:
- Class:
    - A 
        - ```Basic Salary = 10,000```
        - ```MembershipPrice = 500```
    - B 
        - ```Basic Salary = 7,500```
        - ```MembershipPrice = 375```
    - C 
        - ```Basic Salary = 5,000```
        - ```MembershipPrice = 250```
- Gets the **Total # of members (MemberCount)** under this trainer

- Salary:
    - ```Commission = 0.05 * (MembershipPrice * MemberCount)```
    - ```Salary = Basic Salary + Commission```
___

## Additional Changes - optional

- Add a screen for members to book appointments with the trainers
- this screen can show the trainers they are registered with
- along with a calendar that will show when those trainers are free to be booked.

**Should probably do this in a separate branch.**

___