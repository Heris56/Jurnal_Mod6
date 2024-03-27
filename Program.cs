// See https://aka.ms/new-console-template for more information

using System;

class Program()
{
    static void Main(string[] args)
    {
        SayatubeVideo v1 = new SayatubeVideo("VIDEO A");
        SayatubeVideo v2 = new SayatubeVideo("VIDEO B");
        SayatubeVideo v3 = new SayatubeVideo("VIDEO C");
        SayatubeVideo v4 = new SayatubeVideo("VIDEO D");
        v1.increasePlaycount(10000);
        v2.increasePlaycount(10000);
        v3.increasePlaycount(10000);
        v4.increasePlaycount(10000);
        SayatubeUser HR = new SayatubeUser("Haikal");
        HR.addVideo(v1);
        HR.addVideo(v2);
        HR.addVideo(v3);
        HR.addVideo(v4);

        HR.PrintAllVideoPlaycount();
    }
}

public class SayatubeVideo
{
    private int id;
    Random random = new Random();
    private String title;
    private int playCount;
    public SayatubeVideo(String Judul)
    {
        if (String.IsNullOrEmpty(Judul) || Judul.Length > 200)
        {
            Console.WriteLine("inputan tidak valid");
        }
        else
        {
            this.title = Judul;
            this.id = random.Next(10000, 99999);
            this.playCount = 0;
        }
    }

    public void increasePlaycount(int playCount)
    {
        if (playCount > 10000000)
        {
            Console.WriteLine("input Playcount invalid");
        }
        else
        {
            try
            {
                checked
                {
                    this.playCount = this.playCount + playCount;
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("Overflow");
            }
        }
    }

    public int getPlayCount()
    {
        return this.playCount;
    }

    public void printvideoDetails()
    {
        Console.WriteLine("id\t\t: " + this.id);
        Console.WriteLine("title\t\t: " + this.title);
        Console.WriteLine("play count\t: " + this.playCount);
    }
}

public class SayatubeUser
{
    Random random = new Random();
    private int id;
    private List<SayatubeVideo> uploadedVideos;
    public String username;
    public SayatubeUser(String username)
    {
        if (String.IsNullOrEmpty(username) || username.Length > 200)
        {
            Console.WriteLine("Invalid");
        }
        else
        {
            id = random.Next(10000, 99999);
            this.uploadedVideos = new List<SayatubeVideo>();
            this.username = username;
        }
    }
    public int getTotalVideoPlayCount()
    {
        int TVP = 0;
        foreach(SayatubeVideo video in this.uploadedVideos)
        {
            TVP += video.getPlayCount();
        }
        return TVP;
    }

    public void addVideo(SayatubeVideo video)
    {
        this.uploadedVideos.Add(video);
    }
    
    public void PrintAllVideoPlaycount()
    {
        Console.WriteLine("Username: " + this.username);
        for (int i =0; i < uploadedVideos.Count;i++)
        {
            SayatubeVideo video = this.uploadedVideos[i];
            Console.WriteLine("Video" + (i+1) + " : " + video.getPlayCount());
                
        }
        Console.WriteLine("Total Play Count: " + getTotalVideoPlayCount());
    }

}
