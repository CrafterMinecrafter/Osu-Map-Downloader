// ==UserScript==
// @name         Osu Map Downloader
// @namespace    https://github.com/CrafterMinecrafter
// @version      0.0.1
// @description  Auto Map Downloader
// @author       CrafterMinecrafter
// @match        https://osu.ppy.sh/beatmapsets/*
// @grant        none
// ==/UserScript==
// http://tampermonkey.net/

(function() {
    var mapUrl = window.location.href.split("#")[0];
    window.open(mapUrl+"/download?noVideo=1");
    window.open("http://localhost:9524/OsuMapOpener?f=1&mapID="+mapUrl.split("/")[4]);
    window.addEventListener('load', () => {
        document.getElementsByClassName("beatmapset-header__buttons")[0].innerHTML +=
            "<a href='http://localhost:9524/OsuMapOpener?f=2' data-turbolinks='false' class='btn-osu-big btn-osu-big--beatmapset-header js-beatmapset-download-link'><span class='btn-osu-big__content '><span class='btn-osu-big__left'><span class='btn-osu-big__text-top'>Stop checks in server</span></span></a>";
    });

})();

