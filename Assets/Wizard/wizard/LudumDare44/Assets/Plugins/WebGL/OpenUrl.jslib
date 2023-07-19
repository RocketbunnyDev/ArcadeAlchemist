mergeInto(LibraryManager.library, {
  OpenUrl: function(str) {
    window.open(Pointer_stringify(str), "_top");
  }
});