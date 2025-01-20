$(document).ready(function () {

  function updateScoreboard(matches) {
                let tbody = $("#scoreboard tbody");
                tbody.empty();
                matches.forEach(match => {
                    let row = `
                                <tr data-home="${match.homeTeam}" data-away="${match.awayTeam}">
                                    <td>${match.homeTeam}</td>
                                    <td>${match.awayTeam}</td>
                                    <td class="score">${match.homeScore} - ${match.awayScore}</td>
                                    <td>
                                        <div class="d-flex align-items-center gap-2">
                                            <input type="number" class="form-control form-control-sm home-score" min="0" value="${match.homeScore}" required />
                                            <input type="number" class="form-control form-control-sm away-score" min="0" value="${match.awayScore}" required />
                                            <button class="btn btn-primary btn-sm update-score">Update</button>
                                            <button class="btn btn-danger btn-sm finish-game">Finish</button>
                                        </div>
                                    </td>
                                </tr>`;
                    tbody.append(row);
                });
            }

    $(document).on("click", ".update-score", function () {
        let row = $(this).closest("tr");
        let homeTeam = row.data("home");
        let awayTeam = row.data("away");
        let homeScore = row.find(".home-score").val();
        let awayScore = row.find(".away-score").val();

        $.post("/Scoreboard/UpdateScore", { homeTeam, awayTeam, homeScore, awayScore }, function (data) {
            if (data.success) {
                updateScoreboard(data.matches);
                alert("Score updated successfully!");
            } else {
                alert("Error: " + data.message);
            }
        }).fail(function () {
            alert("An error occurred while updating the score.");
        });
    });

    // Finish game event
    $(document).on("click", ".finish-game", function () {
        let row = $(this).closest("tr");
        let homeTeam = row.data("home");
        let awayTeam = row.data("away");

        $.post("/Scoreboard/FinishGame", { homeTeam, awayTeam }, function (data) {
            if (data.success) {
                updateScoreboard(data.matches);
                alert("Game finished successfully!");
            } else {
                alert("Error: " + data.message);
            }
        }).fail(function () {
            alert("An error occurred while finishing the game.");
        });
    });

    // Start a new game event
    $("#startGameForm").on("submit", function (event) {
        event.preventDefault();
        let homeTeam = $("#homeTeam").val();
        let awayTeam = $("#awayTeam").val();

        $.post("/Scoreboard/StartGame", { homeTeam, awayTeam }, function (data) {
            if (data.success) {
                updateScoreboard(data.matches);
                $("#homeTeam").val("");
                $("#awayTeam").val("");
                alert("New game started successfully!");
            } else {
                alert("Error: " + data.message);
            }
        }).fail(function () {
            alert("An error occurred while starting the game.");
        });
    });
});