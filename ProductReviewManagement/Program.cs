using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ProductReview> productReviews = new List<ProductReview>();
            AddDefaultValues(productReviews);
            Program program = new Program();

            //RetrieveProductIdAndReview(productReviews);
            //SkipTop5Records(productReviews);
            program.AddDataInDataTable();
            //program.GetDatatableIsLikeValueYes();
            program.AverateRatingOfProductID();
            Console.ReadKey();
        }
        static public void AddDefaultValues(List<ProductReview> productReviews)
        {
            productReviews.Add(new ProductReview() { productId = 1, userId = 1, rating = 5, isLike = "Yes", review = "Awesome" });
            productReviews.Add(new ProductReview() { productId = 1, userId = 2, rating = 3, isLike = "Yes", review = "Awesome" });
            productReviews.Add(new ProductReview() { productId = 1, userId = 3, rating = 4, isLike = "Yes", review = "Awesome" });
            productReviews.Add(new ProductReview() { productId = 1, userId = 4, rating = 3, isLike = "Yes", review = "Nice" });
            productReviews.Add(new ProductReview() { productId = 1, userId = 5, rating = 4, isLike = "Yes", review = "Good" });
            productReviews.Add(new ProductReview() { productId = 2, userId = 1, rating = 1, isLike = "No", review = "Unsatifactory" });
            productReviews.Add(new ProductReview() { productId = 2, userId = 2, rating = 3, isLike = "Yes", review = "Good" });
            productReviews.Add(new ProductReview() { productId = 2, userId = 3, rating = 4, isLike = "Yes", review = "Awesome" });
            productReviews.Add(new ProductReview() { productId = 2, userId = 4, rating = 3, isLike = "Yes", review = "Nice" });
            productReviews.Add(new ProductReview() { productId = 2, userId = 5, rating = 4, isLike = "Yes", review = "Good" });
            productReviews.Add(new ProductReview() { productId = 3, userId = 1, rating = 5, isLike = "Yes", review = "Awesome" });
            productReviews.Add(new ProductReview() { productId = 3, userId = 2, rating = 3, isLike = "Yes", review = "Awesome" });
            productReviews.Add(new ProductReview() { productId = 3, userId = 3, rating = 4, isLike = "Yes", review = "Awesome" });
            productReviews.Add(new ProductReview() { productId = 3, userId = 4, rating = 3, isLike = "Yes", review = "Nice" });
            productReviews.Add(new ProductReview() { productId = 3, userId = 5, rating = 4, isLike = "Yes", review = "Good" });
            productReviews.Add(new ProductReview() { productId = 4, userId = 1, rating = 1, isLike = "No", review = "Unsatifactory" });
            productReviews.Add(new ProductReview() { productId = 4, userId = 2, rating = 2, isLike = "No", review = "Bad" });
            productReviews.Add(new ProductReview() { productId = 4, userId = 3, rating = 2, isLike = "No", review = "Worst" });
            productReviews.Add(new ProductReview() { productId = 4, userId = 4, rating = 3, isLike = "No", review = "Not good" });
            productReviews.Add(new ProductReview() { productId = 4, userId = 5, rating = 2, isLike = "No", review = "Okay" });
            productReviews.Add(new ProductReview() { productId = 5, userId = 1, rating = 5, isLike = "Yes", review = "Awesome" });
            productReviews.Add(new ProductReview() { productId = 5, userId = 1, rating = 5, isLike = "Yes", review = "Awesome" });
            productReviews.Add(new ProductReview() { productId = 5, userId = 1, rating = 5, isLike = "Yes", review = "Awesome" });
            productReviews.Add(new ProductReview() { productId = 5, userId = 1, rating = 5, isLike = "Yes", review = "Awesome" });
            productReviews.Add(new ProductReview() { productId = 5, userId = 1, rating = 5, isLike = "Yes", review = "Awesome" });
            productReviews.Add(new ProductReview() { productId = 9, userId = 1, rating = 5, isLike = "Yes", review = "Does the work" });
        }

        static public ArrayList GetTop3HighestRatedRecords(List<ProductReview> productReviews)
        {
            ArrayList outputList = new ArrayList();
            var highestRatedRows = (from rec in productReviews
                                    orderby rec.rating descending
                                    select rec).Take(3);
            foreach (var row in highestRatedRows)
            {
                Console.WriteLine(row.ToString());
                outputList.Add(row.ToString());
            }

            return outputList;

        }

        static public ArrayList RatingGreaterThan3(List<ProductReview> productReviews)
        {
            ArrayList outputList = new ArrayList();

            var records = (from rec in productReviews
                           where rec.rating > 3 && (rec.productId == 1 || rec.productId == 3 || rec.productId == 9)
                           select rec);
            foreach (var row in records)
            {
                Console.WriteLine(row.ToString());
                outputList.Add(row.ToString());
            }
            return outputList;
        }

        static public ArrayList CountforeachProductId(List<ProductReview> productReviews)
        {
            ArrayList outputList = new ArrayList();
            var records = (from rec in productReviews
                           group rec by rec.productId into g
                           select new
                           {
                               productId2 = g.Key,
                               ReviewCount = g.Count()
                           });
            foreach (var row in records)
            {
                Console.WriteLine(row.ToString());
                outputList.Add(row.ToString());
            }
            return outputList;
        }
       
        static public ArrayList RetrieveProductIdAndReview(List<ProductReview> productReviews)
        {
            ArrayList outputList = new ArrayList();
            var records = from rec in productReviews
                          select new { rec.productId, rec.review };
                         
            foreach (var row in records)
            {
                Console.WriteLine(row.ToString());
                outputList.Add(row.ToString());
            }
            return outputList;
        }

        static public ArrayList SkipTop5Records(List<ProductReview> productReviews)
        {
            ArrayList outputList = new ArrayList();
            var highestRatedRows = (from rec in productReviews
                                   select rec).Skip(5);
                                  
            foreach (var row in highestRatedRows)
            {
                Console.WriteLine(row.ToString());
                outputList.Add(row.ToString());
            }

            return outputList;

        }

        DataTable datatable = new DataTable();

        public void AddDataInDataTable()
        {
            datatable.Columns.Add("productId", typeof(int));
            datatable.Columns.Add("userId", typeof(int));
            datatable.Columns.Add("rating", typeof(int));
            datatable.Columns.Add("isLike", typeof(string));
            datatable.Columns.Add("review", typeof(string));

            datatable.Rows.Add(1, 1, 5, "Yes","Awesome");
            datatable.Rows.Add(1, 2, 3, "Yes","Awesome");
            datatable.Rows.Add(1, 3, 4, "Yes","Awesome");
            datatable.Rows.Add(1, 4, 3, "Yes","Nice");
            datatable.Rows.Add(1, 5, 4, "Yes","Good");
            datatable.Rows.Add(2, 1, 1, "No", "Unsatifactory");
            datatable.Rows.Add(2, 2, 3, "Yes","Good");
            datatable.Rows.Add(2, 3, 4, "Yes","Awesome");
            datatable.Rows.Add(2, 4, 3, "Yes","Nice");
            datatable.Rows.Add(2, 5, 4, "Yes","Good");
            datatable.Rows.Add(3, 1, 5, "Yes","Awesome");
            datatable.Rows.Add(3, 2, 3, "Yes","Awesome");
            datatable.Rows.Add(3, 3, 4, "Yes","Awesome");
            datatable.Rows.Add(3, 4, 3, "Yes","Nice" );
            datatable.Rows.Add(3, 5, 4, "Yes","Good" );
            datatable.Rows.Add(4, 1, 1, "No", "Unsatifactory");
            datatable.Rows.Add(4, 2, 2, "No", "Bad");
            datatable.Rows.Add(4, 3, 2, "No", "Worst");
            datatable.Rows.Add(4, 4, 3, "No", "Not good");
            datatable.Rows.Add(4, 5, 2, "No", "Okay");
            datatable.Rows.Add(5, 1, 5, "Yes","Awesome");
            datatable.Rows.Add(5, 1, 5, "Yes","Awesome");
            datatable.Rows.Add(5, 1, 5, "Yes","Awesome");
            datatable.Rows.Add(5, 1, 5, "Yes","Awesome");
            datatable.Rows.Add(5, 1, 5, "Yes","Awesome");
            datatable.Rows.Add(9, 1, 5, "Yes","Does the work");
        }

        public void GetDatatableIsLikeValueYes()
        {
            var results = from myRow in datatable.AsEnumerable()
                          where myRow.Field<string>("isLike") == "Yes"
                          select myRow;
            Console.WriteLine(results);
            foreach(var id in results)
            {
                Console.Write(id.ItemArray[0]);
                Console.WriteLine(id.ItemArray[3]);
            }
        }

        public void AverateRatingOfProductID()
        {
            var results = from row in datatable.AsEnumerable()
                          group row by row.Field<int>("productID") into grp
                          select new
                          {
                              productID = grp.Key,
                              averageRating = grp.Average(o => o.Field<int>("rating"))
                          };
            foreach(var row in results)
            {
                Console.WriteLine(row.productID +" = "+ row.averageRating);
            }
        }
    }
}
