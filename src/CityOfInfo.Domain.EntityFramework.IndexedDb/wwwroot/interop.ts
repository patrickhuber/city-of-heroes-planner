// IndexedDbWindow defines properties on our window so we can call them from interop
export interface IndexedDbWindow extends Window {
    databaseFactory: DatabaseFactory
}

// DatabaseFactory wraps the IDBFactory with a singleton instance
class DatabaseFactory {

    private IndexedDb: IDBFactory;

    private static instance: DatabaseFactory;

    private constructor() {
        this.IndexedDb = window.indexedDB;
    }

    public static Instance(): DatabaseFactory {
        if (!DatabaseFactory.instance) {
            DatabaseFactory.instance = new DatabaseFactory();
        }
        return DatabaseFactory.instance;
    }
}

// Cast the global var windows to our custom IndexedDbWindow
declare let window: IndexedDbWindow;