namespace Sudoku.Shared
{
    public class ApiResponse
    {
        public class Grid
        {
            public List<List<int>> value { get; set; }
            public List<List<int>> solution { get; set; }
            public string difficulty { get; set; }
        }

        public class Newboard
        {
            public List<Grid> grids { get; set; }
            public int results { get; set; }
            public string message { get; set; }
        }

        public class Root
        {
            public Newboard newboard { get; set; }
        }
    }

}
