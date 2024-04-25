# Fisher Yates readme

- based on info found in wikipedia and https://www.geeksforgeeks.org/shuffle-a-given-array-using-fisher-yates-shuffle-algorithm/

## Controller
- used dependency injection to add the algorithm service
- added constructor for this purpose
-  annotated to set route and use HTTPGet
- minimal implementation would look like the below
`  public ActionResult Index([FromQuery] string input)
  {
      var validInput = _shuffler.Validate(input);

      if (validInput)
      {
          var output = _shuffler.Shuffle(input);
          var response = new OkObjectResult(_shuffler.ConvertBackToString(output));
          response.ContentTypes.Add("text/plain; charset=utf-8");
          return response;
      }

      var modelState = new ModelStateDictionary();
      modelState.AddModelError("Input", "input is not valid.");
      return new BadRequestObjectResult(modelState);
  }
`

## Service
- added skeleton structure
- - added validation method (yes, I know the brief said to assume that validation is not needed, but that's how trouble happens!)
- - added shuffle method - returns an array that has been shuffled
- - added convertbacktostring method - converts the array back to a string e.g. turns {"D","C","A","B"} into "D-C-A-B"

## Tests
- basic controller tests, mocked service to give desired outcomes
- shuffle tests, tests methods, tests some edge cases

## Packages
- added NUnit for testing, along with Moq and Fluent Assertions

## Next steps
- implement controller
- verify controller tests pass
- then start to implement service methods
- verify tests pass
- add tests for edge cases & refactor service if necessary
- refactor controller if needed

### 24/5/2024
 - basic controller implemented, controller tests now pass