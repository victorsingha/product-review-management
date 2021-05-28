using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewManagement
{
    public class ProductReview
    {
        public int productId { get; set; }
        public int userId { get; set; }
        public int rating { get; set; }
        public string review { get; set; }
        public string isLike { get; set; }

        public override string ToString()
        {
            return productId.ToString() + "," + userId.ToString() + "," + rating.ToString() + "," + review + "," + isLike;
        }
    }

}
