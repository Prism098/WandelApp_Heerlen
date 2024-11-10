using ExotischNederlandKaasus.Models;
using ExotischNederlandKaasus.DAL;
using ExotischNederlandKaasus.Models.ExotischNederlandKaasus.Models;
using System.Text;

class Program
{
    static void Main(string[] args)
    {

        bool continueProgram = true;
        bool exit = false;

        SQLDAL sqlDal = SQLDAL.Instance;


        do
        {
            Console.WriteLine("Select the model you want to interact with:");
            Console.WriteLine("+----+----------------+----+----------------+----+----------------+");
            Console.WriteLine("| No | Model          | No | Model          | No | Model          |");
            Console.WriteLine("+----+----------------+----+----------------+----+----------------+");
            Console.WriteLine("| 1  | Answer         | 2  | Area           | 3  | Game           |");
            Console.WriteLine("| 4  | Observation    | 5  | POI            | 6  | Question       |");
            Console.WriteLine("| 7  | Role           | 8  | Route          | 9  | RoutePoint     |");
            Console.WriteLine("| 10 | Specie         | 11 | User           | 12 | UsrQuest       |");
            Console.WriteLine("| 13 | Kortste Route  | 14 | Play Quiz      | 15 | Exit           |");
            Console.WriteLine("+----+----------------+----+----------------+----+----------------+");

            if (int.TryParse(Console.ReadLine(), out int entityChoice))
            {
                if (entityChoice == 13)
                {
                    continueProgram = HandleRoute();
                    continueProgram = true; // Return to the home screen

                }
                else if (entityChoice == 14)
                {
                    continueProgram = HandlePlayQuiz();
                    continueProgram = true; // Return to the home screen

                }
                else if (entityChoice == 15)
                {
                    continueProgram = false;
                    break;

                }

                Console.WriteLine("Select the action you want to perform:");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Read");
                Console.WriteLine("3. Update");
                Console.WriteLine("4. Delete");

                if (int.TryParse(Console.ReadLine(), out int actionChoice))
                {
                    continueProgram = HandleUserChoice(entityChoice, actionChoice);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        } while (continueProgram);

        // Handle the choice of the user, whenever he chooses what entity he wants to adjust he will fall in this switch case, this switch case refers to another switch case.
        bool HandleUserChoice(int entityChoice, int actionChoice)
        {
            switch (entityChoice)
            {
                case 1:
                    return HandleAnswerActions(actionChoice);
                case 2:
                    return HandleAreaActions(actionChoice);
                case 3:
                    return HandleGameActions(actionChoice);
                case 4:
                    return HandleObservationActions(actionChoice);
                case 5:
                    return HandlePOIActions(actionChoice);
                case 6:
                    return HandleQuestionActions(actionChoice);
                case 7:
                    return HandleRoleActions(actionChoice);
                case 8:
                    return HandleRouteActions(actionChoice);
                case 9:
                    return HandleRoutePointActions(actionChoice);
                case 10:
                    return HandleSpecieActions(actionChoice);
                case 11:
                    return HandleUserActions(actionChoice);
                case 12:
                    return HandleUsrQuestActions(actionChoice);
                case 13:
                    return HandleRoute();
                case 14:
                    return HandlePlayQuiz();
                default:
                    Console.WriteLine("Invalid entity choice.");
                    return true;
            }
        }

        // This is the 2nd layer of switch statements, after the user gave his input of the model he wants to interact with the program will fall in this switch.
        // In this switch the user get the choice between CRUD actions on all entities, this will make them be able to interact with the database directly.
        bool HandleAnswerActions(int actionChoice)
        {
            ANSWER answerInstance = new ANSWER("", 0);

            switch (actionChoice)
            {
                case 1:
                    Console.WriteLine(AddAnswer());
                    return true;
                case 2:
                    Console.WriteLine(ReadAnswers(answerInstance));
                    return true;
                case 3:
                    Console.WriteLine(UpdateAnswer(answerInstance));
                    return true;
                case 4:
                    Console.WriteLine(DeleteAnswer(answerInstance));
                    return true;
                default:
                    Console.WriteLine("Invalid action choice.");
                    return true;
            }
        }
        bool HandleAreaActions(int actionChoice)
        {
            AREA areaInstance = new AREA("OwnerName", "AreaName", "RegionName", "Type");

            switch (actionChoice)
            {
                case 1:
                    Console.WriteLine(AddArea());
                    return true;
                case 2:
                    Console.WriteLine(ReadAreas(areaInstance));
                    return true;
                case 3:
                    Console.WriteLine(UpdateArea(areaInstance));
                    return true;
                case 4:
                    Console.WriteLine(DeleteArea(areaInstance));
                    return true;
                default:
                    Console.WriteLine("Invalid action choice.");
                    return true;
            }
        }
        bool HandleGameActions(int actionChoice)
        {
            GAME gameInstance = new GAME("GameName", DateTime.Now, 1);

            switch (actionChoice)
            {
                case 1:
                    Console.WriteLine(AddGame());
                    return true;
                case 2:
                    Console.WriteLine(ReadGames(gameInstance));
                    return true;
                case 3:
                    Console.WriteLine(UpdateGame(gameInstance));
                    return true;
                case 4:
                    Console.WriteLine(DeleteGame(gameInstance));
                    return true;
                default:
                    Console.WriteLine("Invalid action choice.");
                    return true;
            }
        }
        bool HandleObservationActions(int actionChoice)
        {
            OBSERVATION observationInstance = new OBSERVATION(0, DateTime.Now, string.Empty, string.Empty, 0, 0, 0);

            switch (actionChoice)
            {
                case 1:
                    Console.WriteLine(AddObservation());
                    return true;
                case 2:
                    Console.WriteLine(ReadObservations(observationInstance));
                    return true;
                case 3:
                    Console.WriteLine(UpdateObservation(observationInstance));
                    return true;
                case 4:
                    Console.WriteLine(DeleteObservation(observationInstance));
                    return true;
                default:
                    Console.WriteLine("Invalid action choice.");
                    return true;
            }
        }
        bool HandlePOIActions(int actionChoice)
        {
            POI poiInstance = new POI(0, 0, "", "", 1);
            switch (actionChoice)
            {
                case 1:
                    Console.WriteLine(AddPOI(poiInstance));
                    return true;
                case 2:
                    Console.WriteLine(ReadPOI(poiInstance));
                    return true;
                case 3:
                    Console.WriteLine(UpdatePOI(poiInstance));
                    return true;
                case 4:
                    Console.WriteLine(DeletePOI(poiInstance));
                    return true;
                default:
                    Console.WriteLine("Invalid action choice.");
                    return true;
            }
        }
        bool HandleQuestionActions(int actionChoice)
        {
            QUESTION questionInstance = new QUESTION("", 0);

            switch (actionChoice)
            {
                case 1:
                    Console.WriteLine(AddQuestion());
                    return true;
                case 2:
                    Console.WriteLine(ReadQuestions(questionInstance));
                    return true;
                case 3:
                    Console.WriteLine(UpdateQuestion(questionInstance));
                    return true;
                case 4:
                    Console.WriteLine(DeleteQuestion(questionInstance));
                    return true;
                default:
                    Console.WriteLine("Invalid action choice.");
                    return true;
            }
        }
        bool HandleRoleActions(int actionChoice)
        {
            ROLE roleInstance = new ROLE("", "");

            switch (actionChoice)
            {
                case 1:
                    Console.WriteLine(AddRole());
                    return true;
                case 2:
                    Console.WriteLine(ReadRoles(roleInstance));
                    return true;
                case 3:
                    Console.WriteLine(UpdateRole(roleInstance));
                    return true;
                case 4:
                    Console.WriteLine(DeleteRole(roleInstance));
                    return true;
                default:
                    Console.WriteLine("Invalid action choice.");
                    return true;
            }
        }
        bool HandleRouteActions(int actionChoice)
        {
            ROUTE routeInstance = new ROUTE(0, 0, 0, "", 0);

            switch (actionChoice)
            {
                case 1:
                    Console.WriteLine(AddRoute());
                    return true;
                case 2:
                    Console.WriteLine(ReadRoutes(routeInstance));
                    return true;
                case 3:
                    Console.WriteLine(UpdateRoute(routeInstance));
                    return true;
                case 4:
                    Console.WriteLine(DeleteRoute(routeInstance));
                    return true;
                default:
                    Console.WriteLine("Invalid action choice.");
                    return true;
            }
        }
        bool HandleRoutePointActions(int actionChoice)
        {
            ROUTEPOINT routePointInstance = new ROUTEPOINT(0, 0, 0, 0);

            switch (actionChoice)
            {
                case 1:
                    Console.WriteLine(AddRoutePoint());
                    return true;
                case 2:
                    Console.WriteLine(ReadRoutePoints(routePointInstance));
                    return true;
                case 3:
                    Console.WriteLine(UpdateRoutePoint(routePointInstance));
                    return true;
                case 4:
                    Console.WriteLine(DeleteRoutePoint(routePointInstance));
                    return true;
                default:
                    Console.WriteLine("Invalid action choice.");
                    return true;
            }
        }
        bool HandleSpecieActions(int actionChoice)
        {
            SPECIE specieInstance = new SPECIE("DefaultName", "DefaultInvasivenessLevel");

            switch (actionChoice)
            {
                case 1:
                    Console.WriteLine(AddSpecie());
                    return true;
                case 2:
                    Console.WriteLine(ReadSpecies(specieInstance));
                    return true;
                case 3:
                    Console.WriteLine(UpdateSpecie(specieInstance));
                    return true;
                case 4:
                    Console.WriteLine(DeleteSpecie(specieInstance));
                    return true;
                default:
                    Console.WriteLine("Invalid action choice.");
                    return true;
            }
        }
        bool HandleUserActions(int actionChoice)
        {
            USER userInstance = new USER("DefaultName", "DefaultDescription", 0, 0);

            switch (actionChoice)
            {
                case 1:
                    Console.WriteLine(AddUser());
                    return true;
                case 2:
                    Console.WriteLine(ReadUsers(userInstance));
                    return true;
                case 3:
                    Console.WriteLine(UpdateUser(userInstance));
                    return true;
                case 4:
                    Console.WriteLine(DeleteUser(userInstance));
                    return true;
                default:
                    Console.WriteLine("Invalid action choice.");
                    return true;
            }
        }
        bool HandleUsrQuestActions(int actionChoice)
        {
            USRQUEST usrQuestInstance = new USRQUEST("DefaultAnswerText", 0, 0);

            switch (actionChoice)
            {
                case 1:
                    Console.WriteLine(AddUsrQuest());
                    return true;
                case 2:
                    Console.WriteLine(ReadUsrQuests(usrQuestInstance));
                    return true;
                case 3:
                    Console.WriteLine(UpdateUsrQuest(usrQuestInstance));
                    return true;
                case 4:
                    Console.WriteLine(DeleteUsrQuest(usrQuestInstance));
                    return true;
                default:
                    Console.WriteLine("Invalid action choice.");
                    return true;
            }
        }
        bool HandleRoute()
        {
            return CalculateRoute();
        }
        bool HandlePlayQuiz()
        {
            QUESTION gamequestions = new QUESTION();
            PlayQuiz(gamequestions.Game);
            Console.WriteLine(gamequestions);
            //Console.WriteLine(gameanswers);
            return true;
        }

        // Static methods require no instance of the class to be called. 
        // They are called on the class itself. becaue these or simply utility they do not need to maintain any state.
        // the functions that do get called in the sqlDAL

        // These are the front end scripts that are called in the switch cases above. In these scripts messages get prompted to the user and the user input gets handled.
        // There's also database calls being made trough the Model class to make sure there is a seperation of concerns.
        string AddAnswer()
        {
            Console.WriteLine("Enter the text of the new answer:");
            string answerText = Console.ReadLine();
            Console.WriteLine("Enter the QuestionId for the new answer:");
            if (int.TryParse(Console.ReadLine(), out int questionId))
            {
                ANSWER newAnswer = new ANSWER(answerText, questionId);
                SQLDAL.Instance.AddAnswer(newAnswer);
                return "Answer added successfully.";
            }
            else
            {
                return "Invalid QuestionId entered.";
            }
        }
        string ReadAnswers(ANSWER answerInstance)
        {
            List<ANSWER> answers = answerInstance.GetAnswers();
            StringBuilder result = new StringBuilder();
            result.AppendLine("All answers:");
            foreach (ANSWER answer in answers)
            {
                result.AppendLine($"AnswerId: {answer.AnswerId}, AnswerText: {answer.AnswerText}, QuestionId: {answer.QuestionId}");
            }
            return result.ToString();
        }
        string UpdateAnswer(ANSWER answerInstance)
        {
            var answers = answerInstance.GetAnswers();
            if (answers == null)
            {
                return "No answers available.";
            }

            Console.WriteLine(ReadAnswers(answerInstance));
            Console.WriteLine("Enter the AnswerId of the answer you want to update:");
            string? input = Console.ReadLine();
            if (input == null)
            {
                return "No input provided.";
            }

            if (int.TryParse(input, out int answerIdToUpdate))
            {
                ANSWER? answerToUpdate = answers.Find(a => a.AnswerId == answerIdToUpdate);
                if (answerToUpdate != null)
                {
                    Console.WriteLine("Enter the new text of the answer:");
                    string? newText = Console.ReadLine();
                    if (newText == null)
                    {
                        return "No new text provided.";
                    }

                    answerToUpdate.AnswerText = newText;
                    answerToUpdate.UpdateAnswer(answerToUpdate);
                    return "Answer updated successfully.";
                }
                else
                {
                    return "Answer not found.";
                }
            }
            else
            {
                return "Invalid AnswerId entered.";
            }
        }
        string DeleteAnswer(ANSWER answerInstance)
        {
            Console.WriteLine(ReadAnswers(answerInstance));
            Console.WriteLine("Enter the AnswerId of the answer you want to delete:");
            if (int.TryParse(Console.ReadLine(), out int answerIdToDelete))
            {
                ANSWER answerToDelete = answerInstance.GetAnswers().Find(a => a.AnswerId == answerIdToDelete);
                if (answerToDelete != null)
                {
                    answerToDelete.DeleteAnswer();
                    return "Answer deleted successfully.";
                }
                else
                {
                    return "Answer not found.";
                }
            }
            else
            {
                return "Invalid AnswerId entered.";
            }
        }

        string AddArea()
        {
            Console.WriteLine("Enter the owner of the new area:");
            string owner = Console.ReadLine();
            Console.WriteLine("Enter the name of the new area:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the region of the new area:");
            string region = Console.ReadLine();
            Console.WriteLine("Enter the type of the new area:");
            string type = Console.ReadLine();

            AREA newArea = new AREA(owner, name, region, type);
            newArea.AddArea();
            return "Area added successfully.";
        }
        string ReadAreas(AREA areaInstance)
        {
            List<AREA> areas = areaInstance.GetAreas();
            StringBuilder result = new StringBuilder();
            result.AppendLine("All areas:");
            foreach (AREA area in areas)
            {
                result.AppendLine($"AreaId: {area.AreaId}, Owner: {area.Owner}, Name: {area.Name}, Region: {area.Region}, Type: {area.Type}");
            }
            return result.ToString();
        }
        string UpdateArea(AREA areaInstance)
        {
            Console.WriteLine(ReadAreas(areaInstance));
            Console.WriteLine("Enter the AreaId of the area you want to update:");
            if (int.TryParse(Console.ReadLine(), out int areaIdToUpdate))
            {
                AREA areaToUpdate = areaInstance.GetAreas().Find(a => a.AreaId == areaIdToUpdate);
                if (areaToUpdate != null)
                {
                    Console.WriteLine("Enter the new owner of the area:");
                    areaToUpdate.Owner = Console.ReadLine();
                    Console.WriteLine("Enter the new name of the area:");
                    areaToUpdate.Name = Console.ReadLine();
                    Console.WriteLine("Enter the new region of the area:");
                    areaToUpdate.Region = Console.ReadLine();
                    Console.WriteLine("Enter the new type of the area:");
                    areaToUpdate.Type = Console.ReadLine();

                    areaToUpdate.UpdateArea(areaToUpdate);
                    return "Area updated successfully.";
                }
                else
                {
                    return "Area not found.";
                }
            }
            else
            {
                return "Invalid AreaId entered.";
            }
        }
        string DeleteArea(AREA areaInstance)
        {
            // Display the list of areas
            Console.WriteLine(ReadAreas(areaInstance));

            // Prompt the user to enter the AreaId of the area to delete
            Console.WriteLine("Enter the AreaId of the area you want to delete:");
            if (int.TryParse(Console.ReadLine(), out int areaIdToDelete))
            {
                // Find the area to delete
                AREA areaToDelete = areaInstance.GetAreas().Find(a => a.AreaId == areaIdToDelete);
                if (areaToDelete != null)
                {
                    // Delete the area
                    bool isDeleted = SQLDAL.Instance.DeleteArea(areaIdToDelete);
                    if (isDeleted)
                    {
                        return "Area deleted successfully.";
                    }
                    else
                    {
                        return "Area could not be deleted.";
                    }
                }
                else
                {
                    return "Area not found.";
                }
            }
            else
            {
                return "Invalid AreaId entered.";
            }
        }

        string AddGame()
        {
            Console.WriteLine("Enter the name of the new game:");
            string? name = Console.ReadLine();
            DateTime startTime = DateTime.Now; // Set the start time to the current date and time, inserting the datetime by the user has no value for the application.
            Console.WriteLine("Enter the route ID for the new game:");
            if (int.TryParse(Console.ReadLine(), out int routeId))
            {
                GAME newGame = new GAME(name, startTime, routeId);
                newGame.AddGame();
                return "Game added successfully.";
            }
            else
            {
                return "Invalid route ID entered.";
            }
        }
        string ReadGames(GAME gameInstance)
        {
            List<GAME> games = gameInstance.GetGames();
            StringBuilder result = new();
            result.AppendLine("All games:");
            foreach (GAME game in games)
            {
                result.AppendLine($"GameId: {game.GameId}, Name: {game.Name}, StartTime: {game.StartTime}, RouteId: {game.RouteId}, Points: {game.Points}");
            }
            return result.ToString();
        }
        string UpdateGame(GAME gameInstance)
        {
            Console.WriteLine(ReadGames(gameInstance));
            Console.WriteLine("Enter the GameId of the game you want to update:");
            if (int.TryParse(Console.ReadLine(), out int gameIdToUpdate))
            {
                GAME? gameToUpdate = gameInstance.GetGames().Find(g => g.GameId == gameIdToUpdate);
                if (gameToUpdate != null)
                {
                    Console.WriteLine("Enter the new name of the game:");
                    gameToUpdate.Name = Console.ReadLine();
                    Console.WriteLine("Enter the new route ID for the game:");
                    if (int.TryParse(Console.ReadLine(), out int newRouteId))
                    {
                        gameToUpdate.RouteId = newRouteId;
                        gameToUpdate.UpdateGame(gameToUpdate);
                        return "Game updated successfully.";
                    }
                    else
                    {
                        return "Invalid route ID entered.";
                    }
                }
                else
                {
                    return "Game not found.";
                }
            }
            else
            {
                return "Invalid GameId entered.";
            }
        }
        string DeleteGame(GAME gameInstance)
        {
            Console.WriteLine(ReadGames(gameInstance));
            Console.WriteLine("Enter the GameId of the game you want to delete:");
            if (int.TryParse(Console.ReadLine(), out int gameIdToDelete))
            {
                GAME? gameToDelete = gameInstance.GetGames().Find(g => g.GameId == gameIdToDelete);
                if (gameToDelete != null)
                {
                    gameToDelete.DeleteGame();
                    return "Game deleted successfully.";
                }
                else
                {
                    return "Game not found.";
                }
            }
            else
            {
                return "Invalid GameId entered.";
            }
        }

        string AddObservation()
        {
            DateTime dateObserved = DateTime.Now;
            Console.WriteLine("Enter the observer's name:");
            string? observer = Console.ReadLine();
            Console.WriteLine("Enter the description of the observation:");
            string? description = Console.ReadLine();
            Console.WriteLine("Enter the area ID for the observation:");
            if (int.TryParse(Console.ReadLine(), out int areaId))
            {
                Console.WriteLine("Enter the user ID for the observation:");
                if (int.TryParse(Console.ReadLine(), out int userId))
                {
                    Console.WriteLine("Enter the specie ID for the observation:");
                    if (int.TryParse(Console.ReadLine(), out int specieId))
                    {
                        OBSERVATION newObservation = new(0, dateObserved, observer, description, areaId, userId, specieId);
                        newObservation.AddObservation();
                        return "Observation added successfully.";
                    }
                    else
                    {
                        return "Invalid specie ID entered.";
                    }
                }
                else
                {
                    return "Invalid user ID entered.";
                }
            }
            else
            {
                return "Invalid area ID entered.";
            }
        }
        string ReadObservations(OBSERVATION observationInstance)
        {
            List<OBSERVATION> observations = observationInstance.GetObservation();
            StringBuilder result = new();
            result.AppendLine("All observations:");
            foreach (OBSERVATION observation in observations)
            {
                result.AppendLine($"ObservationId: {observation.ObservationId}, DateObserved: {observation.DateObserved}, Observer: {observation.Observer}, Description: {observation.Description}, AreaId: {observation.AreaId}, UserId: {observation.UserId}, SpecieId: {observation.SpecieId}");
            }
            return result.ToString();
        }
        string UpdateObservation(OBSERVATION observationInstance)
        {
            Console.WriteLine(ReadObservations(observationInstance));
            Console.WriteLine("Enter the ObservationId of the observation you want to update:");
            if (int.TryParse(Console.ReadLine(), out int observationIdToUpdate))
            {
                OBSERVATION? observationToUpdate = observationInstance.GetObservation().Find(o => o.ObservationId == observationIdToUpdate);
                if (observationToUpdate != null)
                {
                    observationToUpdate.DateObserved = DateTime.Now; // Set the date to the current date and time
                    Console.WriteLine("Enter the new observer's name:");
                    observationToUpdate.Observer = Console.ReadLine();
                    Console.WriteLine("Enter the new description of the observation:");
                    observationToUpdate.Description = Console.ReadLine();
                    Console.WriteLine("Enter the new area ID for the observation:");
                    if (int.TryParse(Console.ReadLine(), out int newAreaId))
                    {
                        observationToUpdate.AreaId = newAreaId;
                        Console.WriteLine("Enter the new user ID for the observation:");
                        if (int.TryParse(Console.ReadLine(), out int newUserId))
                        {
                            observationToUpdate.UserId = newUserId;
                            Console.WriteLine("Enter the new specie ID for the observation:");
                            if (int.TryParse(Console.ReadLine(), out int newSpecieId))
                            {
                                observationToUpdate.SpecieId = newSpecieId;
                                observationToUpdate.UpdateObservation(observationToUpdate);
                                return "Observation updated successfully.";
                            }
                            else
                            {
                                return "Invalid specie ID entered.";
                            }
                        }
                        else
                        {
                            return "Invalid user ID entered.";
                        }
                    }
                    else
                    {
                        return "Invalid area ID entered.";
                    }
                }
                else
                {
                    return "Observation not found.";
                }
            }
            else
            {
                return "Invalid ObservationId entered.";
            }
        }
        string DeleteObservation(OBSERVATION observationInstance)
        {
            Console.WriteLine(ReadObservations(observationInstance));
            Console.WriteLine("Enter the ObservationId of the observation you want to delete:");
            if (int.TryParse(Console.ReadLine(), out int observationIdToDelete))
            {
                OBSERVATION? observationToDelete = observationInstance.GetObservation().Find(o => o.ObservationId == observationIdToDelete);
                if (observationToDelete != null)
                {
                    observationToDelete.DeleteObservation();
                    return "Observation deleted successfully.";
                }
                else
                {
                    return "Observation not found.";
                }
            }
            else
            {
                return "Invalid ObservationId entered.";
            }
        }

        string AddPOI(POI poiInstance)
        {
            Console.WriteLine("Enter the longitude of the new POI:");
            if (decimal.TryParse(Console.ReadLine(), out decimal longitude))
            {
                Console.WriteLine("Enter the latitude of the new POI:");
                if (decimal.TryParse(Console.ReadLine(), out decimal latitude))
                {
                    Console.WriteLine("Enter the description of the new POI:");
                    string description = Console.ReadLine();
                    Console.WriteLine("Enter the type of the new POI:");
                    string type = Console.ReadLine();
                    Console.WriteLine("Enter the RoutePointId for the new POI:");
                    if (int.TryParse(Console.ReadLine(), out int routePointId))
                    {
                        POI newPOI = new POI(longitude, latitude, description, type, routePointId);
                        newPOI.AddPOI();
                        return "POI added successfully.";
                    }
                    else
                    {
                        return "Invalid RoutePointId entered.";
                    }
                }
                else
                {
                    return "Invalid latitude entered.";
                }
            }
            else
            {
                return "Invalid longitude entered.";
            }
        }
        string ReadPOI(POI poiInstance)
        {
            List<POI> pois = poiInstance.GetPOI();
            StringBuilder result = new();
            result.AppendLine("All POIs:");
            foreach (POI poi in pois)
            {
                result.AppendLine($"POIId: {poi.POIId}, Longitude: {poi.Longitude}, Latitude: {poi.Latitude}, Description: {poi.Description}, Type: {poi.Type}, RoutePointId: {poi.RoutePointId}");
            }
            return result.ToString();
        }
        string UpdatePOI(POI poiInstance)
        {
            Console.WriteLine(ReadPOI(poiInstance));
            Console.WriteLine("Enter the POIId of the POI you want to update:");
            if (int.TryParse(Console.ReadLine(), out int poiIdToUpdate))
            {
                POI poiToUpdate = poiInstance.GetPOI().Find(p => p.POIId == poiIdToUpdate);
                if (poiToUpdate != null)
                {
                    Console.WriteLine("Enter the new longitude of the POI:");
                    poiToUpdate.Longitude = decimal.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the new latitude of the POI:");
                    poiToUpdate.Latitude = decimal.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the new description of the POI:");
                    poiToUpdate.Description = Console.ReadLine();
                    Console.WriteLine("Enter the new type of the POI:");
                    poiToUpdate.Type = Console.ReadLine();
                    poiInstance.UpdatePOI(poiToUpdate);
                    return "POI updated successfully.";
                }
                else
                {
                    return "POI not found.";
                }
            }
            else
            {
                return "Invalid POIId entered.";
            }
        }
        string DeletePOI(POI poiInstance)
        {
            Console.WriteLine(ReadPOI(poiInstance));
            Console.WriteLine("Enter the POIId of the POI you want to delete:");
            if (int.TryParse(Console.ReadLine(), out int poiIdToDelete))
            {
                POI poiToDelete = poiInstance.GetPOI().Find(p => p.POIId == poiIdToDelete);
                if (poiToDelete != null)
                {
                    poiToDelete.DeletePOI();
                    return "POI deleted successfully.";
                }
                else
                {
                    return "POI not found.";
                }
            }
            else
            {
                return "Invalid POIId entered.";
            }
        }

        string AddQuestion()
        {
            Console.WriteLine("Enter the text of the new question:");
            string questionText = Console.ReadLine();
            Console.WriteLine("Enter the GameId for the new question:");
            if (int.TryParse(Console.ReadLine(), out int gameId))
            {
                QUESTION newQuestion = new QUESTION(questionText, gameId);
                newQuestion.AddQuestion();
                return "Question added successfully.";
            }
            else
            {
                return "Invalid GameId entered.";
            }
        }
        string ReadQuestions(QUESTION questionInstance)
        {
            List<QUESTION> questions = questionInstance.GetQuestions();
            StringBuilder result = new StringBuilder();
            result.AppendLine("All questions:");
            foreach (QUESTION question in questions)
            {
                result.AppendLine($"QuestionId: {question.QuestionId}, QuestionText: {question.QuestionText}, GameId: {question.GameId}");
            }
            return result.ToString();
        }
        string UpdateQuestion(QUESTION questionInstance)
        {
            Console.WriteLine(ReadQuestions(questionInstance));
            Console.WriteLine("Enter the QuestionId of the question you want to update:");
            if (int.TryParse(Console.ReadLine(), out int questionIdToUpdate))
            {
                QUESTION questionToUpdate = questionInstance.GetQuestions().Find(q => q.QuestionId == questionIdToUpdate);
                if (questionToUpdate != null)
                {
                    Console.WriteLine("Enter the new text of the question:");
                    questionToUpdate.QuestionText = Console.ReadLine();
                    questionToUpdate.UpdateQuestion(questionToUpdate);
                    return "Question updated successfully.";
                }
                else
                {
                    return "Question not found.";
                }
            }
            else
            {
                return "Invalid QuestionId entered.";
            }
        }
        string DeleteQuestion(QUESTION questionInstance)
        {
            Console.WriteLine(ReadQuestions(questionInstance));
            Console.WriteLine("Enter the QuestionId of the question you want to delete:");
            if (int.TryParse(Console.ReadLine(), out int questionIdToDelete))
            {
                QUESTION questionToDelete = questionInstance.GetQuestions().Find(q => q.QuestionId == questionIdToDelete);
                if (questionToDelete != null)
                {
                    questionToDelete.DeleteQuestion();
                    return "Question deleted successfully.";
                }
                else
                {
                    return "Question not found.";
                }
            }
            else
            {
                return "Invalid QuestionId entered.";
            }
        }

        string AddRole()
        {
            Console.WriteLine("Enter the name of the new role:");
            string roleName = Console.ReadLine();
            Console.WriteLine("Enter the description of the new role:");
            string roleDescription = Console.ReadLine();
            ROLE newRole = new ROLE(roleName, roleDescription);
            newRole.AddRole();
            return "Role added successfully.";
        }
        string ReadRoles(ROLE roleInstance)
        {
            List<ROLE> roles = roleInstance.GetRoles();
            StringBuilder result = new StringBuilder();
            result.AppendLine("All roles:");
            foreach (ROLE role in roles)
            {
                result.AppendLine($"RoleId: {role.RoleId}, Name: {role.Name}, Description: {role.Description}");
            }
            return result.ToString();
        }
        string UpdateRole(ROLE roleInstance)
        {
            Console.WriteLine(ReadRoles(roleInstance));
            Console.WriteLine("Enter the RoleId of the role you want to update:");
            if (int.TryParse(Console.ReadLine(), out int roleIdToUpdate))
            {
                ROLE roleToUpdate = roleInstance.GetRoles().Find(r => r.RoleId == roleIdToUpdate);
                if (roleToUpdate != null)
                {
                    Console.WriteLine("Enter the new name of the role:");
                    roleToUpdate.Name = Console.ReadLine();
                    Console.WriteLine("Enter the new description of the role:");
                    roleToUpdate.Description = Console.ReadLine();
                    roleToUpdate.UpdateRole(roleToUpdate);
                    return "Role updated successfully.";
                }
                else
                {
                    return "Role not found.";
                }
            }
            else
            {
                return "Invalid RoleId entered.";
            }
        }
        string DeleteRole(ROLE roleInstance)
        {
            Console.WriteLine(ReadRoles(roleInstance));
            Console.WriteLine("Enter the RoleId of the role you want to delete:");
            if (int.TryParse(Console.ReadLine(), out int roleIdToDelete))
            {
                ROLE roleToDelete = roleInstance.GetRoles().Find(r => r.RoleId == roleIdToDelete);
                if (roleToDelete != null)
                {
                    roleToDelete.DeleteRole();
                    return "Role deleted successfully.";
                }
                else
                {
                    return "Role not found.";
                }
            }
            else
            {
                return "Invalid RoleId entered.";
            }
        }

        string AddRoute()
        {
            Console.WriteLine("Enter the length of the new route:");
            if (int.TryParse(Console.ReadLine(), out int length))
            {
                Console.WriteLine("Enter the longitude of the new route:");
                if (decimal.TryParse(Console.ReadLine(), out decimal longitude))
                {
                    Console.WriteLine("Enter the latitude of the new route:");
                    if (decimal.TryParse(Console.ReadLine(), out decimal latitude))
                    {
                        Console.WriteLine("Enter the type of the new route:");
                        string type = Console.ReadLine();
                        Console.WriteLine("Enter the AreaId for the new route:");
                        if (int.TryParse(Console.ReadLine(), out int areaId))
                        {
                            ROUTE newRoute = new ROUTE(length, longitude, latitude, type, areaId);
                            newRoute.AddRoute();
                            return "Route added successfully.";
                        }
                        else
                        {
                            return "Invalid AreaId entered.";
                        }
                    }
                    else
                    {
                        return "Invalid latitude entered.";
                    }
                }
                else
                {
                    return "Invalid longitude entered.";
                }
            }
            else
            {
                return "Invalid length entered.";
            }
        }
        string ReadRoutes(ROUTE routeInstance)
        {
            List<ROUTE> routes = routeInstance.GetRoutes();
            StringBuilder result = new StringBuilder();
            result.AppendLine("All routes:");
            foreach (ROUTE route in routes)
            {
                result.AppendLine($"RouteId: {route.RouteId}, Length: {route.Length}, Longitude: {route.Longitude}, Latitude: {route.Latitude}, Type: {route.Type}, AreaId: {route.AreaId}");
            }
            return result.ToString();
        }
        string UpdateRoute(ROUTE routeInstance)
        {
            Console.WriteLine(ReadRoutes(routeInstance));
            Console.WriteLine("Enter the RouteId of the route you want to update:");
            if (int.TryParse(Console.ReadLine(), out int routeIdToUpdate))
            {
                ROUTE routeToUpdate = routeInstance.GetRoutes().Find(r => r.RouteId == routeIdToUpdate);
                if (routeToUpdate != null)
                {
                    Console.WriteLine("Enter the new length of the route:");
                    if (int.TryParse(Console.ReadLine(), out int newLength))
                    {
                        routeToUpdate.Length = newLength;
                        Console.WriteLine("Enter the new longitude of the route:");
                        if (decimal.TryParse(Console.ReadLine(), out decimal newLongitude))
                        {
                            routeToUpdate.Longitude = newLongitude;
                            Console.WriteLine("Enter the new latitude of the route:");
                            if (decimal.TryParse(Console.ReadLine(), out decimal newLatitude))
                            {
                                routeToUpdate.Latitude = newLatitude;
                                Console.WriteLine("Enter the new type of the route:");
                                routeToUpdate.Type = Console.ReadLine();
                                routeToUpdate.UpdateRoute(routeToUpdate);
                                return "Route updated successfully.";
                            }
                            else
                            {
                                return "Invalid latitude entered.";
                            }
                        }
                        else
                        {
                            return "Invalid longitude entered.";
                        }
                    }
                    else
                    {
                        return "Invalid length entered.";
                    }
                }
                else
                {
                    return "Route not found.";
                }
            }
            else
            {
                return "Invalid RouteId entered.";
            }
        }
        string DeleteRoute(ROUTE routeInstance)
        {
            Console.WriteLine(ReadRoutes(routeInstance));
            Console.WriteLine("Enter the RouteId of the route you want to delete:");
            if (int.TryParse(Console.ReadLine(), out int routeIdToDelete))
            {
                ROUTE routeToDelete = routeInstance.GetRoutes().Find(r => r.RouteId == routeIdToDelete);
                if (routeToDelete != null)
                {
                    routeToDelete.DeleteRoute();
                    return "Route deleted successfully.";
                }
                else
                {
                    return "Route not found.";
                }
            }
            else
            {
                return "Invalid RouteId entered.";
            }
        }

        string AddRoutePoint()
        {
            Console.WriteLine("Enter the longitude of the new route point:");
            if (decimal.TryParse(Console.ReadLine(), out decimal longitude))
            {
                Console.WriteLine("Enter the latitude of the new route point:");
                if (decimal.TryParse(Console.ReadLine(), out decimal latitude))
                {
                    Console.WriteLine("Enter the sequence number of the new route point:");
                    if (int.TryParse(Console.ReadLine(), out int sequenceNumber))
                    {
                        ROUTEPOINT newRoutePoint = new ROUTEPOINT(longitude, latitude, sequenceNumber);
                        newRoutePoint.AddRoutePoint();
                        return "Route point added successfully.";
                    }
                    else
                    {
                        return "Invalid sequence number entered.";
                    }
                }
                else
                {
                    return "Invalid latitude entered.";
                }
            }
            else
            {
                return "Invalid longitude entered.";
            }
        }
        string ReadRoutePoints(ROUTEPOINT routePointInstance)
        {
            List<ROUTEPOINT> routePoints = routePointInstance.GetRoutePoints();
            StringBuilder result = new StringBuilder();
            result.AppendLine("All route points:");
            foreach (ROUTEPOINT routePoint in routePoints)
            {
                result.AppendLine($"RoutePointId: {routePoint.RoutePointId}, Longitude: {routePoint.Longitude}, Latitude: {routePoint.Latitude}, SequenceNumber: {routePoint.SequenceNumber}");
            }
            return result.ToString();
        }
        string UpdateRoutePoint(ROUTEPOINT routePointInstance)
        {
            Console.WriteLine(ReadRoutePoints(routePointInstance));
            Console.WriteLine("Enter the RoutePointId of the route point you want to update:");
            if (int.TryParse(Console.ReadLine(), out int routePointIdToUpdate))
            {
                ROUTEPOINT routePointToUpdate = routePointInstance.GetRoutePoints().Find(rp => rp.RoutePointId == routePointIdToUpdate);
                if (routePointToUpdate != null)
                {
                    Console.WriteLine("Enter the new longitude of the route point:");
                    if (decimal.TryParse(Console.ReadLine(), out decimal newLongitude))
                    {
                        routePointToUpdate.Longitude = newLongitude;
                        Console.WriteLine("Enter the new latitude of the route point:");
                        if (decimal.TryParse(Console.ReadLine(), out decimal newLatitude))
                        {
                            routePointToUpdate.Latitude = newLatitude;
                            Console.WriteLine("Enter the new sequence number of the route point:");
                            if (int.TryParse(Console.ReadLine(), out int newSequenceNumber))
                            {
                                routePointToUpdate.SequenceNumber = newSequenceNumber;
                                routePointToUpdate.UpdateRoutePoint(routePointToUpdate);
                                return "Route point updated successfully.";
                            }
                            else
                            {
                                return "Invalid sequence number entered.";
                            }
                        }
                        else
                        {
                            return "Invalid latitude entered.";
                        }
                    }
                    else
                    {
                        return "Invalid longitude entered.";
                    }
                }
                else
                {
                    return "Route point not found.";
                }
            }
            else
            {
                return "Invalid RoutePointId entered.";
            }
        }
        string DeleteRoutePoint(ROUTEPOINT routePointInstance)
        {
            Console.WriteLine(ReadRoutePoints(routePointInstance));
            Console.WriteLine("Enter the RoutePointId of the route point you want to delete:");
            if (int.TryParse(Console.ReadLine(), out int routePointIdToDelete))
            {
                ROUTEPOINT routePointToDelete = routePointInstance.GetRoutePoints().Find(rp => rp.RoutePointId == routePointIdToDelete);
                if (routePointToDelete != null)
                {
                    routePointToDelete.DeleteRoutePoint();
                    return "Route point deleted successfully.";
                }
                else
                {
                    return "Route point not found.";
                }
            }
            else
            {
                return "Invalid RoutePointId entered.";
            }
        }

        string AddSpecie()
        {
            Console.WriteLine("Enter the name of the new specie:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the invasiveness level of the new specie (optional):");
            string? invasivenessLevel = Console.ReadLine();

            SPECIE newSpecie = new SPECIE(0, name, invasivenessLevel);
            newSpecie.AddSpecie();
            return "Specie added successfully.";
        }
        string ReadSpecies(SPECIE specieInstance)
        {
            List<SPECIE> species = specieInstance.GetSpecies();
            StringBuilder result = new StringBuilder();
            result.AppendLine("All species:");
            foreach (SPECIE specie in species)
            {
                result.AppendLine($"SpecieId: {specie.SpecieId}, Name: {specie.Name}, InvasivenessLevel: {specie.InvasivenessLevel}, Route");
            }
            return result.ToString();
        }
        string UpdateSpecie(SPECIE specieInstance)
        {
            Console.WriteLine(ReadSpecies(specieInstance));
            Console.WriteLine("Enter the SpecieId of the specie you want to update:");
            if (int.TryParse(Console.ReadLine(), out int specieIdToUpdate))
            {
                SPECIE specieToUpdate = specieInstance.GetSpecies().Find(s => s.SpecieId == specieIdToUpdate);
                if (specieToUpdate != null)
                {
                    Console.WriteLine("Enter the new name of the specie:");
                    string? newName = Console.ReadLine();
                    specieToUpdate.Name = newName;
                    Console.WriteLine("Enter the new invasiveness level of the specie (optional):");
                    string? newInvasivenessLevel = Console.ReadLine();
                    specieToUpdate.InvasivenessLevel = newInvasivenessLevel;
                    specieToUpdate.UpdateSpecie(specieToUpdate);
                    return "Specie updated successfully.";
                }
                else
                {
                    return "Specie not found.";
                }
            }
            else
            {
                return "Invalid SpecieId entered.";
            }
        }
        string DeleteSpecie(SPECIE specieInstance)
        {
            Console.WriteLine(ReadSpecies(specieInstance));
            Console.WriteLine("Enter the SpecieId of the specie you want to delete:");
            if (int.TryParse(Console.ReadLine(), out int specieIdToDelete))
            {
                SPECIE specieToDelete = specieInstance.GetSpecies().Find(s => s.SpecieId == specieIdToDelete);
                if (specieToDelete != null)
                {
                    specieToDelete.DeleteSpecie();
                    return "Specie deleted successfully.";
                }
                else
                {
                    return "Specie not found.";
                }
            }
            else
            {
                return "Invalid SpecieId entered.";
            }
        }

        string AddUser()
        {
            Console.WriteLine("Enter the name of the new user:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the description of the new user (optional):");
            string? description = Console.ReadLine();
            Console.WriteLine("Enter the role of the new user:");
            if (int.TryParse(Console.ReadLine(), out int role))
            {
                Console.WriteLine("Enter the route ID of the new user:");
                if (int.TryParse(Console.ReadLine(), out int routeId))
                {
                    USER newUser = new USER(name, description, role, routeId);
                    newUser.AddUser();
                    return "User added successfully.";
                }
                else
                {
                    return "Invalid route ID entered.";
                }
            }
            else
            {
                return "Invalid role entered.";
            }
        }
        string ReadUsers(USER userInstance)
        {
            List<USER> users = userInstance.GetUsers();
            StringBuilder result = new StringBuilder();
            result.AppendLine("All users:");
            foreach (USER user in users)
            {
                result.AppendLine($"UserId: {user.UserId}, Name: {user.Name}, Description: {user.Description}, Role: {user.Role}, Experience: {user.Experience}, RouteId: {user.RouteId}");
            }
            return result.ToString();
        }
        string UpdateUser(USER userInstance)
        {
            Console.WriteLine(ReadUsers(userInstance));
            Console.WriteLine("Enter the UserId of the user you want to update:");
            if (int.TryParse(Console.ReadLine(), out int userIdToUpdate))
            {
                USER userToUpdate = userInstance.GetUsers().Find(u => u.UserId == userIdToUpdate);
                if (userToUpdate != null)
                {
                    Console.WriteLine("Enter the new name of the user:");
                    string newName = Console.ReadLine();
                    userToUpdate.Name = newName;
                    Console.WriteLine("Enter the new description of the user (optional):");
                    string? newDescription = Console.ReadLine();
                    userToUpdate.Description = newDescription;
                    Console.WriteLine("Enter the new role of the user:");
                    if (int.TryParse(Console.ReadLine(), out int newRole))
                    {
                        userToUpdate.Role = newRole;
                        Console.WriteLine("Enter the new route ID of the user:");
                        if (int.TryParse(Console.ReadLine(), out int newRouteId))
                        {
                            userToUpdate.RouteId = newRouteId;
                            userToUpdate.UpdateUser(userToUpdate);
                            return "User updated successfully.";
                        }
                        else
                        {
                            return "Invalid route ID entered.";
                        }
                    }
                    else
                    {
                        return "Invalid role entered.";
                    }
                }
                else
                {
                    return "User not found.";
                }
            }
            else
            {
                return "Invalid UserId entered.";
            }
        }
        string DeleteUser(USER userInstance)
        {
            Console.WriteLine(ReadUsers(userInstance));
            Console.WriteLine("Enter the UserId of the user you want to delete:");
            if (int.TryParse(Console.ReadLine(), out int userIdToDelete))
            {
                USER userToDelete = userInstance.GetUsers().Find(u => u.UserId == userIdToDelete);
                if (userToDelete != null)
                {
                    userToDelete.DeleteUser();
                    return "User deleted successfully.";
                }
                else
                {
                    return "User not found.";
                }
            }
            else
            {
                return "Invalid UserId entered.";
            }
        }

        string AddUsrQuest()
        {
            Console.WriteLine("Enter the answer text for the new user quest:");
            string answerText = Console.ReadLine();
            Console.WriteLine("Enter the user ID for the new user quest:");
            if (int.TryParse(Console.ReadLine(), out int userId))
            {
                Console.WriteLine("Enter the question ID for the new user quest:");
                if (int.TryParse(Console.ReadLine(), out int questionId))
                {
                    USRQUEST newUsrQuest = new USRQUEST(answerText, userId, questionId);
                    newUsrQuest.AddUsrQuest();
                    return "User quest added successfully.";
                }
                else
                {
                    return "Invalid question ID entered.";
                }
            }
            else
            {
                return "Invalid user ID entered.";
            }
        }
        string ReadUsrQuests(USRQUEST usrQuestInstance)
        {
            List<USRQUEST> usrQuests = usrQuestInstance.GetUsrQuests();
            StringBuilder result = new StringBuilder();
            result.AppendLine("All user quests:");
            foreach (USRQUEST usrQuest in usrQuests)
            {
                result.AppendLine($"UsrQuestId: {usrQuest.UsrQuestId}, AnswerText: {usrQuest.AnswerText}, UserId: {usrQuest.UserId}, QuestionId: {usrQuest.QuestionId}");
            }
            return result.ToString();
        }
        string UpdateUsrQuest(USRQUEST usrQuestInstance)
        {
            Console.WriteLine(ReadUsrQuests(usrQuestInstance));
            Console.WriteLine("Enter the UsrQuestId of the user quest you want to update:");
            if (int.TryParse(Console.ReadLine(), out int usrQuestIdToUpdate))
            {
                USRQUEST usrQuestToUpdate = usrQuestInstance.GetUsrQuests().Find(uq => uq.UsrQuestId == usrQuestIdToUpdate);
                if (usrQuestToUpdate != null)
                {
                    Console.WriteLine("Enter the new answer text for the user quest:");
                    string newAnswerText = Console.ReadLine();
                    usrQuestToUpdate.AnswerText = newAnswerText;
                    Console.WriteLine("Enter the new user ID for the user quest:");
                    if (int.TryParse(Console.ReadLine(), out int newUserId))
                    {
                        // Check if the new user ID exists
                        if (SQLDAL.Instance.GetUsers().Any(u => u.UserId == newUserId))
                        {
                            usrQuestToUpdate.UserId = newUserId;
                            Console.WriteLine("Enter the new question ID for the user quest:");
                            if (int.TryParse(Console.ReadLine(), out int newQuestionId))
                            {
                                // Check if the new question ID exists
                                if (SQLDAL.Instance.GetQuestions().Any(q => q.QuestionId == newQuestionId))
                                {
                                    usrQuestToUpdate.QuestionId = newQuestionId;
                                    usrQuestToUpdate.UpdateUsrQuest(usrQuestToUpdate);
                                    return "User quest updated successfully.";
                                }
                                else
                                {
                                    return "Invalid question ID entered. Question ID does not exist.";
                                }
                            }
                            else
                            {
                                return "Invalid question ID entered.";
                            }
                        }
                        else
                        {
                            return "Invalid user ID entered. User ID does not exist.";
                        }
                    }
                    else
                    {
                        return "Invalid user ID entered.";
                    }
                }
                else
                {
                    return "User quest not found.";
                }
            }
            else
            {
                return "Invalid UsrQuestId entered.";
            }
        }
        string DeleteUsrQuest(USRQUEST usrQuestInstance)
        {
            Console.WriteLine(ReadUsrQuests(usrQuestInstance));
            Console.WriteLine("Enter the UsrQuestId of the user quest you want to delete:");
            if (int.TryParse(Console.ReadLine(), out int usrQuestIdToDelete))
            {
                USRQUEST usrQuestToDelete = usrQuestInstance.GetUsrQuests().Find(uq => uq.UsrQuestId == usrQuestIdToDelete);
                if (usrQuestToDelete != null)
                {
                    usrQuestToDelete.DeleteUsrQuest();
                    return "User quest deleted successfully.";
                }
                else
                {
                    return "User quest not found.";
                }
            }
            else
            {
                return "Invalid UsrQuestId entered.";
            }
        }


        // Method to fetch a random question and check the answer
        static string PlayQuiz(GAME gamequestions)
        {
            bool keepPlaying = true; // Bool to check if the user wants to keep playing
            var sqlDAL = SQLDAL.Instance; // Get the instance of SQLDAL

            // Fetch all questions and answers
            List<QUESTION> questions = sqlDAL.GetQuestions();
            List<ANSWER> answers = sqlDAL.GetAnswers();

            Random random = new Random(); // Random object to select random questions

            while (keepPlaying) // Loop to keep playing the quiz until the user stops
            {
                // Select a random question
                int randomIndex = random.Next(questions.Count);
                QUESTION randomQuestion = questions[randomIndex];

                // Find the correct answer for the selected question
                ANSWER correctAnswer = answers.FirstOrDefault(a => a.QuestionId == randomQuestion.QuestionId);

                Console.WriteLine("Here's your question:");
                Console.WriteLine(randomQuestion.QuestionText);

                Console.Write("Your answer (TRUE/FALSE): ");
                string userAnswer = Console.ReadLine()?.Trim().ToLower(); // Get user input and convert to lower case to avoid typos

                // Check user answer with the correct answer from the db
                if (correctAnswer == null)
                {
                    Console.WriteLine("No correct answer found for this question.");
                }
                else if (userAnswer == correctAnswer.AnswerText?.ToLower())
                {
                    Console.WriteLine("Correct!");
                }
                else
                {
                    Console.WriteLine($"Incorrect! The correct answer is: {correctAnswer.AnswerText}");
                }

                Console.Write("\nContinue playing? Type 'stop' to quit, or press Enter to continue: ");
                string continuePlaying = Console.ReadLine()?.Trim().ToLower();

                // If statement to exit the quiz
                if (continuePlaying == "stop")
                {
                    keepPlaying = false;
                    Console.WriteLine("See you next time!");
                }
            }

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
            return ""; // Return empty string because it's not a void method, but must return a string
        }
        //Methode om route tussen twee nodes te berekenen
        static bool CalculateRoute()
        {
            // een 15 x 15 matrix die de aftanden tussen de locaties voorstelt
            int[,] graph = new int[15, 15]
            {
                    { 0, 10, 10, 12, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 10, 0, 3, 0, 0, 0, 0, 14, 0, 0, 0, 18, 0, 0, 0 },
                    { 10, 3, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 12, 0, 3, 0, 10, 9, 10, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 10, 0, 4, 0, 0, 13, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 9, 4, 0, 3, 0, 13, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 10, 0, 3, 0, 2, 14, 0, 0, 0, 0, 0, 0 },
                    { 0, 14, 0, 0, 0, 0, 2, 0, 0, 0, 1, 6, 0, 0, 0 },
                    { 0, 0, 0, 0, 13, 13, 14, 0, 0, 11, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 11, 0, 6, 0, 6, 6, 6 },
                    { 0, 0, 0, 0, 0, 0, 0, 1, 0, 6, 0, 6, 4, 0, 0 },
                    { 0, 18, 0, 0, 0, 0, 0, 6, 0, 0, 6, 0, 5, 9, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 4, 5, 0, 3, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 0, 9, 3, 0, 8 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 0, 0, 0, 8, 0 } //15 nodes , waarbij de index 0-14 de locaties voorstellen en de afstand hier tussen
            };

            // Defineer elke node met de gegeven naam van de locatie
            Dictionary<int, string> nodeNames = new Dictionary<int, string>
                {
                    { 0, "Het Weerterbos" },
                    { 1, "Moeselpeel" },
                    { 2, "Roeventerpeel" },
                    { 3, "Natuurreservaat Wellensteijn" },
                    { 4, "Het Spaanse Bos" },
                    { 5, "Landgoed Beijlshof" },
                    { 6, "Landgoed Exaten" },
                    { 7, "De Tuspeel" },
                    { 8, "Beesels Broek" },
                    { 9, "Melickerheide" },
                    { 10, "Isabelle Griend en Oolder Griend" },
                    { 11, "Molengreend" },
                    { 12, "Linnerheide" },
                    { 13, "Het Munnichsbos" },
                    { 14, "Nationaal park de Meinweg" }
                };

            // Geef de locaties weer voor de gebruiker
            Console.WriteLine("Available locations:");
            foreach (var location in nodeNames)
            {
                Console.WriteLine($"{location.Key + 1}. {location.Value}");
            }

            // Vraag gebruiker voor een start en eind locatie in integer formaat
            Console.Write("\nEnter the starting location number: ");
            int startNode = GetNodeInput(nodeNames.Count) - 1;

            Console.Write("Enter the target location number: ");
            int targetNode = GetNodeInput(nodeNames.Count) - 1;

            // Bereken en geef het kortste pad tussen de opgegeven locaties weer
            List<int> path = ROUTE.FindShortestPath(graph, startNode, targetNode);

            if (path.Count > 0)
            {
                Console.WriteLine($"\nShortest path from {nodeNames[startNode]} to {nodeNames[targetNode]}:");
                int totalDistance = 0; // Variable to keep track of total distance
                for (int i = 0; i < path.Count - 1; i++)
                {
                    int currentNode = path[i];
                    int nextNode = path[i + 1];
                    totalDistance += graph[currentNode, nextNode]; // Add the distance between nodes

                    Console.Write(nodeNames[currentNode]);
                    if (i < path.Count - 2)
                        Console.Write(" -> ");
                }
                Console.WriteLine($"\nTotal distance: {totalDistance} km");
            }
            else
            {
                Console.WriteLine($"\nNo path found from {nodeNames[startNode]} to {nodeNames[targetNode]}.");
            }

            // Wait for user input before returning to the menu
            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
            return false;

        }
        // metehode on een juiste gebruikers input te krijgen
        static int GetNodeInput(int numLocations)
        {
            int node;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out node) && node >= 1 && node <= numLocations)
                {
                    return node;
                }
                Console.WriteLine("Invalid input. Please enter a valid location number:");
            }

        }
    }
}