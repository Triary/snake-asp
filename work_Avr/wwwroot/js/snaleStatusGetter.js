class SnakeStatusGetter {
    #_intervalId;
    #_timeout;

    constructor(timeout) {
        this.#_timeout = timeout;
    }

    #Updater(_this) {
        $.ajax("api/GetSnakeStatusDataModel", {})
            .done(function (responseData) {
                console.log(responseData)
                if (responseData.isSnakeAlive === false) {
                   // setTimeout(function () {
                        alert("Game over");
                   // }, _this.#_timeout);
                    _this.Stop();

                }
            })
    }

    Start() {
        this.Stop()
        this.#_intervalId=setInterval(this.#Updater, this.#_timeout, this);
    }

    Stop() {
        if (this.#_intervalId)
        {
            clearInterval(this.#_intervalId);
        }
    }
}