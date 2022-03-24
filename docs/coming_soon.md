# Coming soon

### How subscription flow works from app webview
A WebView might be useful if the merchant needs more control over the UI and advanced configuration options that will allow the Merchant to embed web pages in a specially-designed environment for their app.

If you use WebViews in your app, the user will experience single device flow - MobilePay app will get opened for user to continue the flow.
Functionality will be available for users with MobilePay app version 5.16 (and higher). ETA: May release.

<div class="note">

<strong>Important configuration for Android Webview<strong>
<br>
In <strong>Android<strong> app if you set <code>WebViewClient</code> on Webview, then you must override <code>shouldOverrideUrlLoading</code> method exactly like this:
<code>
    <pre>
    webView.setWebViewClient(new WebViewClient() {
        @Override
        public boolean shouldOverrideUrlLoading(WebView view, String url) {
            Uri uri = Uri.parse(url);
            if (uri.getHost().toLowerCase().contains("open.mobilepay.dk")) {
                Intent intent = new Intent(Intent.ACTION_VIEW, uri);
                intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK | Intent.FLAG_ACTIVITY_CLEAR_TASK);
                startActivity(intent);
                return true;
            }
            return false;
        }
    });
    </pre>
</code>
Without this code MobilePay app will not get opened. Users with older than MobilePay app version 5.16 will see the "Landing Page" dual device scenario.

</div>
