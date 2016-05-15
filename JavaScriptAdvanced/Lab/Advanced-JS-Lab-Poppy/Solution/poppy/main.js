poppy.pop('success', 'Test', 'success');
poppy.pop('info', 'Test', 'info');
poppy.pop('error', 'Test', 'error');
poppy.pop('warning', 'Test', 'warning', function() {
    alert('warning');
});
