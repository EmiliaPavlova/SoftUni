app.factory('videoData', function(){
    var videos = [{
        title: 'Course',
        pictureUrl: "",
        length: '3:32',
        category: 'IT',
        subscribers: 3,
        date: new Date(2015, 11, 15),
        haveSubtitles: false,
        comments: [
            {
                username: 'Pesho Peshev',
                content: 'Some content',
                date: new Date(2015, 11, 15, 12, 30, 0),
                likes: 3,
                websiteUrl: 'http://pesho.com/'
            }
        ]
    },
        {
            title: 'Course introduction 2',
            pictureUrl: "http://www.nakov.com/wp-content/uploads/2014/05/SoftUni-Logo.png",
            length: '6:32',
            category: 'DT',
            subscribers: 2,
            date: new Date(2015, 03, 10),
            haveSubtitles: true,
            comments: [
                {
                    username: 'Pesho Peshev',
                    content: 'Congratulations Nakov',
                    date: new Date(2016, 03, 15, 12, 30, 0),
                    likes: 3,
                    websiteUrl: 'http://pesho.com/'
                }
            ]
        }];

    return {
        getVideos: videos,
        addVideo: function addVideo(video){
            videos.push(video);
        }
    }
});