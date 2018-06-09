using System;
namespace xamarinAndroidTaskApp
{
    public class Task
    {
        public String shortDescription { get; set; }
        public String longDescription { get; set; }
        public int percentage { get; set; }

        public Task(String shortDescription, String longDescription, int percentage)
        {
            this.shortDescription = shortDescription;
            this.longDescription = longDescription;
            this.percentage = percentage;
        }
        public Task()
        {

        }

        public override String ToString(){
            return string.Format("Short description: {0}, percentage: {1}",
                                 this.shortDescription, this.percentage);
        }
    }
}
