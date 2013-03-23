Ext.application({
    name: "GeekFlicks",
    appFolder: "app",
    launch: function () {
        Ext.create('Ext.container.Viewport', {
            layout: 'fit',
            items: [{
                xtype: 'panel',
                title: 'Flicks for Geeks',
                html: 'Add your favorite geeky movies'
            }]
        });
    }
});