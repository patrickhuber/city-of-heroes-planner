define(["require", "exports"], function (require, exports) {
    "use strict";
    Object.defineProperty(exports, "__esModule", { value: true });
    // DatabaseFactory wraps the IDBFactory with a singleton instance
    class DatabaseFactory {
        constructor() {
            this.IndexedDb = window.indexedDB;
        }
        static Instance() {
            if (!DatabaseFactory.instance) {
                DatabaseFactory.instance = new DatabaseFactory();
            }
            return DatabaseFactory.instance;
        }
    }
});
//# sourceMappingURL=interop.js.map