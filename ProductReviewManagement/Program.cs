using System;
using System.Collections;
using System.Collections.Generic;
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
            RetrieveProductIdAndReview(productReviews);
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
    }
}
