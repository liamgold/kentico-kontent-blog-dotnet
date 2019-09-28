import { config, dom, library } from '@fortawesome/fontawesome-svg-core';
import { faBlog } from '@fortawesome/free-solid-svg-icons/faBlog';

library.add(faBlog);

config.keepOriginalSource = false;

// Kicks off the process of finding <i> tags and replacing with <svg>
dom.watch();
