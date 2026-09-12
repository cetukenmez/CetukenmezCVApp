(function () {
    'use strict';

    var root = document.documentElement;

    /* ---------- Theme toggle ---------- */
    var themeToggle = document.getElementById('theme-toggle');
    if (themeToggle) {
        themeToggle.addEventListener('click', function () {
            var next = root.getAttribute('data-theme') === 'dark' ? 'light' : 'dark';
            root.setAttribute('data-theme', next);
            try { localStorage.setItem('theme', next); } catch (e) { }
        });
    }

    /* ---------- Mobile navigation ---------- */
    var navToggle = document.getElementById('nav-toggle');
    var nav = document.getElementById('site-nav');
    if (navToggle && nav) {
        var setOpen = function (open) {
            nav.classList.toggle('open', open);
            navToggle.setAttribute('aria-expanded', String(open));
            navToggle.setAttribute('aria-label', open ? 'Close menu' : 'Open menu');
            navToggle.querySelector('i').className = open ? 'fa-solid fa-xmark' : 'fa-solid fa-bars';
        };
        navToggle.addEventListener('click', function () {
            setOpen(!nav.classList.contains('open'));
        });
        nav.addEventListener('click', function (e) {
            if (e.target.tagName === 'A') setOpen(false);
        });
        document.addEventListener('keydown', function (e) {
            if (e.key === 'Escape') setOpen(false);
        });
    }

    /* ---------- Reveal on scroll ---------- */
    var revealEls = document.querySelectorAll('.reveal');
    if ('IntersectionObserver' in window) {
        var revealObserver = new IntersectionObserver(function (entries) {
            entries.forEach(function (entry) {
                if (entry.isIntersecting) {
                    entry.target.classList.add('in');
                    revealObserver.unobserve(entry.target);
                }
            });
        }, { rootMargin: '0px 0px -8% 0px', threshold: 0.05 });
        revealEls.forEach(function (el) { revealObserver.observe(el); });
        // Safety net: never leave content hidden if the observer misbehaves (e.g. during a long smooth scroll to a hash).
        window.setTimeout(function () {
            revealEls.forEach(function (el) { el.classList.add('in'); });
        }, 2500);
    } else {
        revealEls.forEach(function (el) { el.classList.add('in'); });
    }

    /* ---------- Active nav link ---------- */
    var navLinks = nav ? Array.prototype.slice.call(nav.querySelectorAll('a[href^="#"]')) : [];
    var sections = navLinks
        .map(function (a) { return document.querySelector(a.getAttribute('href')); })
        .filter(Boolean);

    if (sections.length && 'IntersectionObserver' in window) {
        var activeId = null;
        var sectionObserver = new IntersectionObserver(function (entries) {
            entries.forEach(function (entry) {
                if (entry.isIntersecting) activeId = entry.target.id;
            });
            navLinks.forEach(function (a) {
                a.classList.toggle('active', a.getAttribute('href') === '#' + activeId);
            });
        }, { rootMargin: '-40% 0px -55% 0px', threshold: 0 });
        sections.forEach(function (s) { sectionObserver.observe(s); });
    }

    /* ---------- Scroll progress + back to top ---------- */
    var progress = document.querySelector('.scroll-progress');
    var backToTop = document.getElementById('back-to-top');
    var ticking = false;

    var onScroll = function () {
        var scrollTop = window.scrollY || document.documentElement.scrollTop;
        var height = document.documentElement.scrollHeight - window.innerHeight;
        if (progress) progress.style.width = (height > 0 ? (scrollTop / height) * 100 : 0) + '%';
        if (backToTop) backToTop.classList.toggle('visible', scrollTop > 600);
        ticking = false;
    };

    window.addEventListener('scroll', function () {
        if (!ticking) { window.requestAnimationFrame(onScroll); ticking = true; }
    }, { passive: true });
    onScroll();

    if (backToTop) {
        backToTop.addEventListener('click', function () {
            window.scrollTo({ top: 0, behavior: 'smooth' });
        });
    }
})();
