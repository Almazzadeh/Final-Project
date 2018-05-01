Image Slider Maker README
=========================
ImageSliderMaker.com


Using in your website
---------------------

Please first make sure you have fully extracted the contents of the zip file.
In Windows, right-click on imageslidermaker.zip and select Extract All...

To get your slider working in your web page, you must add
my-slider.css, ism-2.2.min.js and the slide images to your project
directory and paste the markup (included below) into your HTML.

The directory structure of this package:

  imageslidermaker/
    README.txt
    example.html
    ism/
      css/
        my-slider.css
      js/
        ism-2.2.min.js
      image/
        slides/
          _u/1520944266499_854035.jpg
          _u/1520944266387_143721.jpg
          _u/1520944266363_25906.jpg

For a working example, open example.html in your web browser or
follow the instructions below to integrate the slider into your
project.


Step by step instructions
-------------------------

1. Paste the following into the head of your HTML file:

<link href="http://fonts.googleapis.com/css?family=Lato" rel="stylesheet" type="text/css">
<link rel="stylesheet" href="ism/css/my-slider.css"/>
<script src="ism/js/ism-2.2.min.js"></script>


2. Paste this into the body of your HTML file (at the location where:
   you would like your slider to appear in the page):

<div class="ism-slider" data-transition_type="zoom" data-play_type="loop" data-image_fx="zoomrotate" id="my-slider">
  <ol>
    <li>
      <img src="ism/image/slides/_u/1520944266499_854035.jpg">
      <div class="ism-caption ism-caption-0" data-delay='400'>High Quality VR Glasses</div>
      <div class="ism-caption ism-caption-1" data-delay='600'>3D Daydream View</div>
      <div class="ism-caption ism-caption-2" data-delay='800'>Starting at $49.99</div>
    </li>
    <li>
      <img src="ism/image/slides/_u/1520944266387_143721.jpg">
      <div class="ism-caption ism-caption-0" data-delay='400'>Get Free Bluetooth when buy</div>
      <div class="ism-caption ism-caption-1" data-delay='600'>Flat SmartWatch</div>
      <div class="ism-caption ism-caption-2" data-delay='800'>Combo Only $590.00</div>
    </li>
    <li>
      <img src="ism/image/slides/_u/1520944266363_25906.jpg">
      <div class="ism-caption ism-caption-0" data-delay='400'>No restocking free ($35 savings)</div>
      <div class="ism-caption ism-caption-1" data-delay='600'>M75 Sport Watch</div>
      <div class="ism-caption ism-caption-2" data-delay='800'>Now Only $320.99</div>
    </li>
  </ol>
</div>
<p class="ism-badge" id="my-slider-ism-badge"><a class="ism-link" href="http://imageslidermaker.com" rel="nofollow">generated with ISM</a></p>


3. Copy the ism/ directory into the root directory of your project.

   The css, js and image paths are relative, meaning the ism/
   directory should be in the same directory (path) as your HTML
   file containing the slider.


Support
-------

If you need support or have a suggestion please get in touch using
the contact form at ImageSliderMaker.com/contact or send an email
to support@imageslidermaker.com

