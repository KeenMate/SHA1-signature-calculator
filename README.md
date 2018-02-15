# SHA1-signature-calculator
SHA1 digest calculator in easy to use WPF

## The reasoning
The original reason for this app to be created was the required calculation of X-Hub-Signature HTTP header that is used in Azure Functions GitHub webhook. The X-Hub-Signature header expects value in sha1=[[sha1 digest]] format, but the calculator generates simple SHA1 signature.

## Functionality
Simply put your secret key in the Secret textbox and your payload in the Payload field. WPF reacts to all changes in both fields and recalculates the SHA1 signature promptly.

Enjoy.
