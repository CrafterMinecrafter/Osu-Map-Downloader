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
    window.open("http://localhost:9524/OsuMapOpener?f=1&mapID="+mapUrl.split("/")[4]);
})();

