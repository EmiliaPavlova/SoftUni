app.controller('VideoController', function($scope, videoData) {
    $scope.videos = videoData.getVideos;
    $scope.isHidden = true;
    $scope.buttonName = "Add Video";
    $scope.filterCategory = [];
    $scope.filterDate = [];

    updateDates();
    createFilters();

    function createFilters(){
        $scope.videos.forEach(function(video) {
            if($scope.filterCategory.indexOf(video.category) < 0){
                $scope.filterCategory.push(video.category);
            }
            if($scope.filterDate.indexOf(video.dateAsString) < 0){
                $scope.filterDate.push(video.dateAsString);
            }
        });
    }

    function updateDates() {
        $scope.videos.forEach(function (video) {
            video.dateAsString = dateToString(video.date);
        });
    }

    function dateToString(date) {
        return date.getDate() + "-" + (date.getMonth() + 1) + "-" + date.getFullYear();
    };

    $scope.subtitles = function(haveSubtitles){
        return haveSubtitles ? "Yes" : "No";
    };

    $scope.addVideo = function(){
        if($scope.isHidden){
            $scope.isHidden = false;
            $scope.buttonName = "Close Form";
        }
        else{
            $scope.isHidden = true;
            $scope.buttonName = "Add Video";
        }
    };

    $scope.formSubmit = function(video){
        videoData.addVideo(video);
        $scope.video = {};
        $scope.videoForm.$setPristine();
        updateDates();
        createFilters();
    }
});