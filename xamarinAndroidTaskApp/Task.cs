using System;
namespace xamarinAndroidTaskApp
{
    public class Task
    {
        public String shortDescription;
        public String longDescription;
        public int percentage;

        public Task()
        {
        }

        public override String ToString(){
            return string.Format("Short description: {0}, percentage: {1}",
                                 this.shortDescription, this.percentage);
        }
    }
}
