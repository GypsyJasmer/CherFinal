
# ZAP Scanning Report

Generated on Wed, 17 Mar 2021 12:19:53


## Summary of Alerts

| Risk Level | Number of Alerts |
| --- | --- |
| High | 1 |
| Medium | 6 |
| Low | 18 |
| Informational | 13 |

## Alerts

| Name | Risk Level | Number of Instances |
| --- | --- | --- | 
| Cross Site Scripting (Reflected) | High | 2 | 
| Cross-Domain Misconfiguration | Medium | 3 | 
| Format String Error | Medium | 1 | 
| X-Frame-Options Header Not Set | Medium | 35 | 
| Cookie No HttpOnly Flag | Low | 2 | 
| Cookie Without SameSite Attribute | Low | 4 | 
| Cookie Without Secure Flag | Low | 2 | 
| Incomplete or No Cache-control and Pragma HTTP Header Set | Low | 75 | 
| Private IP Disclosure | Low | 1 | 
| Server Leaks Information via "X-Powered-By" HTTP Response Header Field(s) | Low | 61 | 
| X-Content-Type-Options Header Missing | Low | 75 | 
| Charset Mismatch  | Informational | 1 | 
| Information Disclosure - Sensitive Information in URL | Informational | 1 | 
| Information Disclosure - Suspicious Comments | Informational | 24 | 
| Loosely Scoped Cookie | Informational | 7 | 
| Timestamp Disclosure - Unix | Informational | 366 | 

## Alert Detail


  
  
  
  
### Cross Site Scripting (Reflected)
##### High (Low)
  
  
  
  
#### Description
<p>Cross-site Scripting (XSS) is an attack technique that involves echoing attacker-supplied code into a user's browser instance. A browser instance can be a standard web browser client, or a browser object embedded in a software product such as the browser within WinAmp, an RSS reader, or an email client. The code itself is usually written in HTML/JavaScript, but may also extend to VBScript, ActiveX, Java, Flash, or any other browser-supported technology.</p><p>When an attacker gets a user's browser to execute his/her code, the code will run within the security context (or zone) of the hosting web site. With this level of privilege, the code has the ability to read, modify and transmit any sensitive data accessible by the browser. A Cross-site Scripted user could have his/her account hijacked (cookie theft), their browser redirected to another location, or possibly shown fraudulent content delivered by the web site they are visiting. Cross-site Scripting attacks essentially compromise the trust relationship between a user and the web site. Applications utilizing browser object instances which load content from the file system may execute code under the local machine zone allowing for system compromise.</p><p></p><p>There are three types of Cross-site Scripting attacks: non-persistent, persistent and DOM-based.</p><p>Non-persistent attacks and DOM-based attacks require a user to either visit a specially crafted link laced with malicious code, or visit a malicious web page containing a web form, which when posted to the vulnerable site, will mount the attack. Using a malicious form will oftentimes take place when the vulnerable resource only accepts HTTP POST requests. In such a case, the form can be submitted automatically, without the victim's knowledge (e.g. by using JavaScript). Upon clicking on the malicious link or submitting the malicious form, the XSS payload will get echoed back and will get interpreted by the user's browser and execute. Another technique to send almost arbitrary requests (GET and POST) is by using an embedded client, such as Adobe Flash.</p><p>Persistent attacks occur when the malicious code is submitted to a web site where it's stored for a period of time. Examples of an attacker's favorite targets often include message board posts, web mail messages, and web chat software. The unsuspecting user is not required to interact with any additional site/link (e.g. an attacker site or a malicious link sent via email), just simply view the web page containing the code.</p>
  
  
  
* URL: [https://localhost:44308/account/login?returnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D4](https://localhost:44308/account/login?returnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D4)
  
  
  * Method: `POST`
  
  
  * Parameter: `RememberMe`
  
  
  * Attack: `<script>alert(1);</script>`
  
  
  * Evidence: `<script>alert(1);</script>`
  
  
  
  
* URL: [https://localhost:44308/account/login](https://localhost:44308/account/login)
  
  
  * Method: `POST`
  
  
  * Parameter: `RememberMe`
  
  
  * Attack: `<script>alert(1);</script>`
  
  
  * Evidence: `<script>alert(1);</script>`
  
  
  
  
Instances: 2
  
### Solution
<p>Phase: Architecture and Design</p><p>Use a vetted library or framework that does not allow this weakness to occur or provides constructs that make this weakness easier to avoid.</p><p>Examples of libraries and frameworks that make it easier to generate properly encoded output include Microsoft's Anti-XSS library, the OWASP ESAPI Encoding module, and Apache Wicket.</p><p></p><p>Phases: Implementation; Architecture and Design</p><p>Understand the context in which your data will be used and the encoding that will be expected. This is especially important when transmitting data between different components, or when generating outputs that can contain multiple encodings at the same time, such as web pages or multi-part mail messages. Study all expected communication protocols and data representations to determine the required encoding strategies.</p><p>For any data that will be output to another web page, especially any data that was received from external inputs, use the appropriate encoding on all non-alphanumeric characters.</p><p>Consult the XSS Prevention Cheat Sheet for more details on the types of encoding and escaping that are needed.</p><p></p><p>Phase: Architecture and Design</p><p>For any security checks that are performed on the client side, ensure that these checks are duplicated on the server side, in order to avoid CWE-602. Attackers can bypass the client-side checks by modifying values after the checks have been performed, or by changing the client to remove the client-side checks entirely. Then, these modified values would be submitted to the server.</p><p></p><p>If available, use structured mechanisms that automatically enforce the separation between data and code. These mechanisms may be able to provide the relevant quoting, encoding, and validation automatically, instead of relying on the developer to provide this capability at every point where output is generated.</p><p></p><p>Phase: Implementation</p><p>For every web page that is generated, use and specify a character encoding such as ISO-8859-1 or UTF-8. When an encoding is not specified, the web browser may choose a different encoding by guessing which encoding is actually being used by the web page. This can cause the web browser to treat certain sequences as special, opening up the client to subtle XSS attacks. See CWE-116 for more mitigations related to encoding/escaping.</p><p></p><p>To help mitigate XSS attacks against the user's session cookie, set the session cookie to be HttpOnly. In browsers that support the HttpOnly feature (such as more recent versions of Internet Explorer and Firefox), this attribute can prevent the user's session cookie from being accessible to malicious client-side scripts that use document.cookie. This is not a complete solution, since HttpOnly is not supported by all browsers. More importantly, XMLHTTPRequest and other powerful browser technologies provide read access to HTTP headers, including the Set-Cookie header in which the HttpOnly flag is set.</p><p></p><p>Assume all input is malicious. Use an "accept known good" input validation strategy, i.e., use an allow list of acceptable inputs that strictly conform to specifications. Reject any input that does not strictly conform to specifications, or transform it into something that does. Do not rely exclusively on looking for malicious or malformed inputs (i.e., do not rely on a deny list). However, deny lists can be useful for detecting potential attacks or determining which inputs are so malformed that they should be rejected outright.</p><p></p><p>When performing input validation, consider all potentially relevant properties, including length, type of input, the full range of acceptable values, missing or extra inputs, syntax, consistency across related fields, and conformance to business rules. As an example of business rule logic, "boat" may be syntactically valid because it only contains alphanumeric characters, but it is not valid if you are expecting colors such as "red" or "blue."</p><p></p><p>Ensure that you perform input validation at well-defined interfaces within the application. This will help protect the application even if a component is reused or moved elsewhere.</p>
  
### Other information
<p>Raised with LOW confidence as the Content-Type is not HTML</p>
  
### Reference
* http://projects.webappsec.org/Cross-Site-Scripting
* http://cwe.mitre.org/data/definitions/79.html

  
#### CWE Id : 79
  
#### WASC Id : 8
  
#### Source ID : 1

  
  
  
  
### Cross-Domain Misconfiguration
##### Medium (Medium)
  
  
  
  
#### Description
<p>Web browser data loading may be possible, due to a Cross Origin Resource Sharing (CORS) misconfiguration on the web server</p>
  
  
  
* URL: [https://static.doubleclick.net/instream/ad_status.js](https://static.doubleclick.net/instream/ad_status.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `Access-Control-Allow-Origin: *`
  
  
  
  
Instances: 1
  
### Solution
<p>Ensure that sensitive data is not available in an unauthenticated manner (using IP address white-listing, for instance).</p><p>Configure the "Access-Control-Allow-Origin" HTTP header to a more restrictive set of domains, or remove all CORS headers entirely, to allow the web browser to enforce the Same Origin Policy (SOP) in a more restrictive manner.</p>
  
### Other information
<p>The CORS misconfiguration on the web server permits cross-domain read requests from arbitrary third party domains, using unauthenticated APIs on this domain. Web browser implementations do not permit arbitrary third parties to read the response from authenticated APIs, however. This reduces the risk somewhat. This misconfiguration could be used by an attacker to access data that is available in an unauthenticated manner, but which uses some other form of security, such as IP address white-listing.</p>
  
### Reference
* http://www.hpenterprisesecurity.com/vulncat/en/vulncat/vb/html5_overly_permissive_cors_policy.html

  
#### CWE Id : 264
  
#### WASC Id : 14
  
#### Source ID : 3

  
  
  
  
### Cross-Domain Misconfiguration
##### Medium (Medium)
  
  
  
  
#### Description
<p>Web browser data loading may be possible, due to a Cross Origin Resource Sharing (CORS) misconfiguration on the web server</p>
  
  
  
* URL: [https://fonts.gstatic.com/s/roboto/v18/KFOmCnqEu92Fr1Mu4mxK.woff2](https://fonts.gstatic.com/s/roboto/v18/KFOmCnqEu92Fr1Mu4mxK.woff2)
  
  
  * Method: `GET`
  
  
  * Evidence: `Access-Control-Allow-Origin: *`
  
  
  
  
Instances: 1
  
### Solution
<p>Ensure that sensitive data is not available in an unauthenticated manner (using IP address white-listing, for instance).</p><p>Configure the "Access-Control-Allow-Origin" HTTP header to a more restrictive set of domains, or remove all CORS headers entirely, to allow the web browser to enforce the Same Origin Policy (SOP) in a more restrictive manner.</p>
  
### Other information
<p>The CORS misconfiguration on the web server permits cross-domain read requests from arbitrary third party domains, using unauthenticated APIs on this domain. Web browser implementations do not permit arbitrary third parties to read the response from authenticated APIs, however. This reduces the risk somewhat. This misconfiguration could be used by an attacker to access data that is available in an unauthenticated manner, but which uses some other form of security, such as IP address white-listing.</p>
  
### Reference
* http://www.hpenterprisesecurity.com/vulncat/en/vulncat/vb/html5_overly_permissive_cors_policy.html

  
#### CWE Id : 264
  
#### WASC Id : 14
  
#### Source ID : 3

  
  
  
  
### Cross-Domain Misconfiguration
##### Medium (Medium)
  
  
  
  
#### Description
<p>Web browser data loading may be possible, due to a Cross Origin Resource Sharing (CORS) misconfiguration on the web server</p>
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/monitor/collections/changes/records](https://firefox.settings.services.mozilla.com/v1/buckets/monitor/collections/changes/records)
  
  
  * Method: `GET`
  
  
  * Evidence: `Access-Control-Allow-Origin: *`
  
  
  
  
Instances: 1
  
### Solution
<p>Ensure that sensitive data is not available in an unauthenticated manner (using IP address white-listing, for instance).</p><p>Configure the "Access-Control-Allow-Origin" HTTP header to a more restrictive set of domains, or remove all CORS headers entirely, to allow the web browser to enforce the Same Origin Policy (SOP) in a more restrictive manner.</p>
  
### Other information
<p>The CORS misconfiguration on the web server permits cross-domain read requests from arbitrary third party domains, using unauthenticated APIs on this domain. Web browser implementations do not permit arbitrary third parties to read the response from authenticated APIs, however. This reduces the risk somewhat. This misconfiguration could be used by an attacker to access data that is available in an unauthenticated manner, but which uses some other form of security, such as IP address white-listing.</p>
  
### Reference
* http://www.hpenterprisesecurity.com/vulncat/en/vulncat/vb/html5_overly_permissive_cors_policy.html

  
#### CWE Id : 264
  
#### WASC Id : 14
  
#### Source ID : 3

  
  
  
  
### Format String Error
##### Medium (Medium)
  
  
  
  
#### Description
<p>A Format String error occurs when the submitted data of an input string is evaluated as a command by the application. </p>
  
  
  
* URL: [https://localhost:44308/fanclub/stories](https://localhost:44308/fanclub/stories)
  
  
  * Method: `POST`
  
  
  * Parameter: `Title`
  
  
  * Attack: `ZAP %1!s%2!s%3!s%4!s%5!s%6!s%7!s%8!s%9!s%10!s%11!s%12!s%13!s%14!s%15!s%16!s%17!s%18!s%19!s%20!s%21!n%22!n%23!n%24!n%25!n%26!n%27!n%28!n%29!n%30!n%31!n%32!n%33!n%34!n%35!n%36!n%37!n%38!n%39!n%40!n
`
  
  
  
  
Instances: 1
  
### Solution
<p>Rewrite the background program using proper deletion of bad character strings.  This will require a recompile of the background executable.</p>
  
### Other information
<p>Potential Format String Error.  The script closed the connection on a microsoft format string error</p>
  
### Reference
* https://owasp.org/www-community/attacks/Format_string_attack

  
#### CWE Id : 134
  
#### WASC Id : 6
  
#### Source ID : 1

  
  
  
  
### X-Frame-Options Header Not Set
##### Medium (Medium)
  
  
  
  
#### Description
<p>X-Frame-Options header is not included in the HTTP response to protect against 'ClickJacking' attacks.</p>
  
  
  
* URL: [https://www.youtube.com/embed/qLq6k6Ckafg](https://www.youtube.com/embed/qLq6k6Ckafg)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
  
Instances: 1
  
### Solution
<p>Most modern Web browsers support the X-Frame-Options HTTP header. Ensure it's set on all web pages returned by your site (if you expect the page to be framed only by pages on your server (e.g. it's part of a FRAMESET) then you'll want to use SAMEORIGIN, otherwise if you never expect the page to be framed, you should use DENY. Alternatively consider implementing Content Security Policy's "frame-ancestors" directive. </p>
  
### Reference
* https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-Frame-Options

  
#### CWE Id : 16
  
#### WASC Id : 15
  
#### Source ID : 3

  
  
  
  
### X-Frame-Options Header Not Set
##### Medium (Medium)
  
  
  
  
#### Description
<p>X-Frame-Options header is not included in the HTTP response to protect against 'ClickJacking' attacks.</p>
  
  
  
* URL: [https://localhost:44308/Account/Login?ReturnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D2](https://localhost:44308/Account/Login?ReturnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D2)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
  
* URL: [https://localhost:44308/account/login](https://localhost:44308/account/login)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
  
* URL: [https://localhost:44308/account/login?returnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D1](https://localhost:44308/account/login?returnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D1)
  
  
  * Method: `POST`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
  
* URL: [https://localhost:44308/Account/Login?ReturnUrl=%2Ffanclub%2Fstories](https://localhost:44308/Account/Login?ReturnUrl=%2Ffanclub%2Fstories)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
  
* URL: [https://localhost:44308/Account/Login?ReturnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D1](https://localhost:44308/Account/Login?ReturnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D1)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
  
* URL: [https://localhost:44308/account/register](https://localhost:44308/account/register)
  
  
  * Method: `POST`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
  
* URL: [https://localhost:44308/career](https://localhost:44308/career)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
  
* URL: [https://localhost:44308/Account/Login?ReturnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D4](https://localhost:44308/Account/Login?ReturnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D4)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
  
* URL: [https://localhost:44308/account/login](https://localhost:44308/account/login)
  
  
  * Method: `POST`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
  
* URL: [https://localhost:44308/fashion/favorite](https://localhost:44308/fashion/favorite)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
  
* URL: [https://localhost:44308/Account/Login?ReturnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D3](https://localhost:44308/Account/Login?ReturnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D3)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
  
* URL: [https://localhost:44308/fanclub/comment?storyId=4](https://localhost:44308/fanclub/comment?storyId=4)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
  
* URL: [https://localhost:44308/account/login?returnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D4](https://localhost:44308/account/login?returnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D4)
  
  
  * Method: `POST`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
  
* URL: [https://localhost:44308/fashion](https://localhost:44308/fashion)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
  
* URL: [https://localhost:44308/account/login?returnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D2](https://localhost:44308/account/login?returnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D2)
  
  
  * Method: `POST`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
  
* URL: [https://localhost:44308/career/albums](https://localhost:44308/career/albums)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
  
* URL: [https://localhost:44308/fashion/seventies](https://localhost:44308/fashion/seventies)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
  
* URL: [https://localhost:44308/account/login?returnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D3](https://localhost:44308/account/login?returnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D3)
  
  
  * Method: `POST`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
  
* URL: [https://localhost:44308/fanclub/stories](https://localhost:44308/fanclub/stories)
  
  
  * Method: `POST`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
  
* URL: [https://localhost:44308/career/tv](https://localhost:44308/career/tv)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Frame-Options`
  
  
  
  
Instances: 34
  
### Solution
<p>Most modern Web browsers support the X-Frame-Options HTTP header. Ensure it's set on all web pages returned by your site (if you expect the page to be framed only by pages on your server (e.g. it's part of a FRAMESET) then you'll want to use SAMEORIGIN, otherwise if you never expect the page to be framed, you should use DENY. Alternatively consider implementing Content Security Policy's "frame-ancestors" directive. </p>
  
### Reference
* https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-Frame-Options

  
#### CWE Id : 16
  
#### WASC Id : 15
  
#### Source ID : 3

  
  
  
  
### Cookie No HttpOnly Flag
##### Low (Medium)
  
  
  
  
#### Description
<p>A cookie has been set without the HttpOnly flag, which means that the cookie can be accessed by JavaScript. If a malicious script can be run on this page then the cookie will be accessible and can be transmitted to another site. If this is a session cookie then session hijacking may be possible.</p>
  
  
  
* URL: [https://googleads.g.doubleclick.net/pagead/id](https://googleads.g.doubleclick.net/pagead/id)
  
  
  * Method: `GET`
  
  
  * Parameter: `test_cookie`
  
  
  * Evidence: `Set-Cookie: test_cookie`
  
  
  
  
* URL: [https://googleads.g.doubleclick.net/pagead/id?slf_rd=1](https://googleads.g.doubleclick.net/pagead/id?slf_rd=1)
  
  
  * Method: `GET`
  
  
  * Parameter: `test_cookie`
  
  
  * Evidence: `Set-Cookie: test_cookie`
  
  
  
  
Instances: 2
  
### Solution
<p>Ensure that the HttpOnly flag is set for all cookies.</p>
  
### Reference
* https://owasp.org/www-community/HttpOnly

  
#### CWE Id : 16
  
#### WASC Id : 13
  
#### Source ID : 3

  
  
  
  
### Cookie Without SameSite Attribute
##### Low (Medium)
  
  
  
  
#### Description
<p>A cookie has been set with an invalid SameSite attribute value, which means that the cookie can be sent as a result of a 'cross-site' request. The SameSite attribute is an effective counter measure to cross-site request forgery, cross-site script inclusion, and timing attacks.</p>
  
  
  
* URL: [https://googleads.g.doubleclick.net/pagead/id?slf_rd=1](https://googleads.g.doubleclick.net/pagead/id?slf_rd=1)
  
  
  * Method: `GET`
  
  
  * Parameter: `test_cookie`
  
  
  * Evidence: `Set-Cookie: test_cookie`
  
  
  
  
* URL: [https://googleads.g.doubleclick.net/pagead/id](https://googleads.g.doubleclick.net/pagead/id)
  
  
  * Method: `GET`
  
  
  * Parameter: `test_cookie`
  
  
  * Evidence: `Set-Cookie: test_cookie`
  
  
  
  
Instances: 2
  
### Solution
<p>Ensure that the SameSite attribute is set to either 'lax' or ideally 'strict' for all cookies.</p>
  
### Reference
* https://tools.ietf.org/html/draft-ietf-httpbis-cookie-same-site

  
#### CWE Id : 16
  
#### WASC Id : 13
  
#### Source ID : 3

  
  
  
  
### Cookie Without SameSite Attribute
##### Low (Medium)
  
  
  
  
#### Description
<p>A cookie has been set with an invalid SameSite attribute value, which means that the cookie can be sent as a result of a 'cross-site' request. The SameSite attribute is an effective counter measure to cross-site request forgery, cross-site script inclusion, and timing attacks.</p>
  
  
  
* URL: [https://www.youtube.com/embed/qLq6k6Ckafg](https://www.youtube.com/embed/qLq6k6Ckafg)
  
  
  * Method: `GET`
  
  
  * Parameter: `YSC`
  
  
  * Evidence: `Set-Cookie: YSC`
  
  
  
  
* URL: [https://www.youtube.com/embed/qLq6k6Ckafg](https://www.youtube.com/embed/qLq6k6Ckafg)
  
  
  * Method: `GET`
  
  
  * Parameter: `VISITOR_INFO1_LIVE`
  
  
  * Evidence: `Set-Cookie: VISITOR_INFO1_LIVE`
  
  
  
  
Instances: 2
  
### Solution
<p>Ensure that the SameSite attribute is set to either 'lax' or ideally 'strict' for all cookies.</p>
  
### Reference
* https://tools.ietf.org/html/draft-ietf-httpbis-cookie-same-site

  
#### CWE Id : 16
  
#### WASC Id : 13
  
#### Source ID : 3

  
  
  
  
### Cookie Without Secure Flag
##### Low (Medium)
  
  
  
  
#### Description
<p>A cookie has been set without the secure flag, which means that the cookie can be accessed via unencrypted connections.</p>
  
  
  
* URL: [https://localhost:44308/account/register](https://localhost:44308/account/register)
  
  
  * Method: `GET`
  
  
  * Parameter: `.AspNetCore.Antiforgery.Im_XXCz2JSw`
  
  
  * Evidence: `Set-Cookie: .AspNetCore.Antiforgery.Im_XXCz2JSw`
  
  
  
  
* URL: [https://localhost:44308/fashion/delete](https://localhost:44308/fashion/delete)
  
  
  * Method: `POST`
  
  
  * Parameter: `.AspNetCore.Mvc.CookieTempDataProvider`
  
  
  * Evidence: `Set-Cookie: .AspNetCore.Mvc.CookieTempDataProvider`
  
  
  
  
Instances: 2
  
### Solution
<p>Whenever a cookie contains sensitive information or is a session token, then it should always be passed using an encrypted channel. Ensure that the secure flag is set for cookies containing such sensitive information.</p>
  
### Reference
* https://owasp.org/www-project-web-security-testing-guide/v41/4-Web_Application_Security_Testing/06-Session_Management_Testing/02-Testing_for_Cookies_Attributes.html

  
#### CWE Id : 614
  
#### WASC Id : 13
  
#### Source ID : 3

  
  
  
  
### Incomplete or No Cache-control and Pragma HTTP Header Set
##### Low (Medium)
  
  
  
  
#### Description
<p>The cache-control and pragma HTTP header have not been set properly or are missing allowing the browser and proxies to cache content.</p>
  
  
  
* URL: [https://versioncheck.addons.mozilla.org/update/VersionCheck.php?reqVersion=2&id=reset-search-defaults@mozilla.com&version=1.0.5&maxAppVersion=86.0&status=userEnabled,incompatible&appID=%7Bec8030f7-c20a-464f-9b0e-13a3a9e97384%7D&appVersion=86.0.1&appOS=WINNT&appABI=x86_64-msvc&locale=en-US&currentAppVersion=86.0.1&updateType=49&compatMode=normal](https://versioncheck.addons.mozilla.org/update/VersionCheck.php?reqVersion=2&id=reset-search-defaults@mozilla.com&version=1.0.5&maxAppVersion=86.0&status=userEnabled,incompatible&appID=%7Bec8030f7-c20a-464f-9b0e-13a3a9e97384%7D&appVersion=86.0.1&appOS=WINNT&appABI=x86_64-msvc&locale=en-US&currentAppVersion=86.0.1&updateType=49&compatMode=normal)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `max-age=3600`
  
  
  
  
Instances: 1
  
### Solution
<p>Whenever possible ensure the cache-control HTTP header is set with no-cache, no-store, must-revalidate; and that the pragma HTTP header is set with no-cache.</p>
  
### Reference
* https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html#web-content-caching

  
#### CWE Id : 525
  
#### WASC Id : 13
  
#### Source ID : 3

  
  
  
  
### Incomplete or No Cache-control and Pragma HTTP Header Set
##### Low (Medium)
  
  
  
  
#### Description
<p>The cache-control and pragma HTTP header have not been set properly or are missing allowing the browser and proxies to cache content.</p>
  
  
  
* URL: [https://aus5.mozilla.org/update/3/SystemAddons/86.0.1/20210310152336/WINNT_x86_64-msvc-x64/en-US/release/Windows_NT%2010.0.0.0.19041.867%20(x64)/default/default/update.xml](https://aus5.mozilla.org/update/3/SystemAddons/86.0.1/20210310152336/WINNT_x86_64-msvc-x64/en-US/release/Windows_NT%2010.0.0.0.19041.867%20(x64)/default/default/update.xml)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `public, max-age=90`
  
  
  
  
Instances: 1
  
### Solution
<p>Whenever possible ensure the cache-control HTTP header is set with no-cache, no-store, must-revalidate; and that the pragma HTTP header is set with no-cache.</p>
  
### Reference
* https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html#web-content-caching

  
#### CWE Id : 525
  
#### WASC Id : 13
  
#### Source ID : 3

  
  
  
  
### Incomplete or No Cache-control and Pragma HTTP Header Set
##### Low (Medium)
  
  
  
  
#### Description
<p>The cache-control and pragma HTTP header have not been set properly or are missing allowing the browser and proxies to cache content.</p>
  
  
  
* URL: [https://www.youtube.com/s/player/223a7479/www-player-webp.css](https://www.youtube.com/s/player/223a7479/www-player-webp.css)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `public, max-age=31536000`
  
  
  
  
Instances: 1
  
### Solution
<p>Whenever possible ensure the cache-control HTTP header is set with no-cache, no-store, must-revalidate; and that the pragma HTTP header is set with no-cache.</p>
  
### Reference
* https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html#web-content-caching

  
#### CWE Id : 525
  
#### WASC Id : 13
  
#### Source ID : 3

  
  
  
  
### Incomplete or No Cache-control and Pragma HTTP Header Set
##### Low (Medium)
  
  
  
  
#### Description
<p>The cache-control and pragma HTTP header have not been set properly or are missing allowing the browser and proxies to cache content.</p>
  
  
  
* URL: [https://snippets.cdn.mozilla.net/us-west/bundles-pregen/Firefox/en-us/default.json](https://snippets.cdn.mozilla.net/us-west/bundles-pregen/Firefox/en-us/default.json)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `max-age=600`
  
  
  
  
Instances: 1
  
### Solution
<p>Whenever possible ensure the cache-control HTTP header is set with no-cache, no-store, must-revalidate; and that the pragma HTTP header is set with no-cache.</p>
  
### Reference
* https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html#web-content-caching

  
#### CWE Id : 525
  
#### WASC Id : 13
  
#### Source ID : 3

  
  
  
  
### Incomplete or No Cache-control and Pragma HTTP Header Set
##### Low (Medium)
  
  
  
  
#### Description
<p>The cache-control and pragma HTTP header have not been set properly or are missing allowing the browser and proxies to cache content.</p>
  
  
  
* URL: [https://localhost:44308/career/tv](https://localhost:44308/career/tv)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://localhost:44308/fanclub/stories](https://localhost:44308/fanclub/stories)
  
  
  * Method: `POST`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://localhost:44308/fashion/seventies](https://localhost:44308/fashion/seventies)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://localhost:44308/career/film](https://localhost:44308/career/film)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://localhost:44308/fanclub/stories](https://localhost:44308/fanclub/stories)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://localhost:44308/career/albums](https://localhost:44308/career/albums)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://localhost:44308/account/login?returnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D3](https://localhost:44308/account/login?returnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D3)
  
  
  * Method: `POST`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://localhost:44308/Account/Login?ReturnUrl=%2Ffanclub%2Fstories](https://localhost:44308/Account/Login?ReturnUrl=%2Ffanclub%2Fstories)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://localhost:44308/fanclub/quiz](https://localhost:44308/fanclub/quiz)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://localhost:44308/lib/bootstrap/dist/css/bootstrap.min.css](https://localhost:44308/lib/bootstrap/dist/css/bootstrap.min.css)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://localhost:44308/account/login?returnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D4](https://localhost:44308/account/login?returnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D4)
  
  
  * Method: `POST`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://localhost:44308/](https://localhost:44308/)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://localhost:44308/fanclub/quiz](https://localhost:44308/fanclub/quiz)
  
  
  * Method: `POST`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://localhost:44308/fashion/ninties](https://localhost:44308/fashion/ninties)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://localhost:44308/fanclub](https://localhost:44308/fanclub)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://localhost:44308/account/register](https://localhost:44308/account/register)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://localhost:44308/account/register](https://localhost:44308/account/register)
  
  
  * Method: `POST`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://localhost:44308/fashion/favorite](https://localhost:44308/fashion/favorite)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://localhost:44308/account/login](https://localhost:44308/account/login)
  
  
  * Method: `POST`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://localhost:44308/account/login](https://localhost:44308/account/login)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
Instances: 37
  
### Solution
<p>Whenever possible ensure the cache-control HTTP header is set with no-cache, no-store, must-revalidate; and that the pragma HTTP header is set with no-cache.</p>
  
### Reference
* https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html#web-content-caching

  
#### CWE Id : 525
  
#### WASC Id : 13
  
#### Source ID : 3

  
  
  
  
### Incomplete or No Cache-control and Pragma HTTP Header Set
##### Low (Medium)
  
  
  
  
#### Description
<p>The cache-control and pragma HTTP header have not been set properly or are missing allowing the browser and proxies to cache content.</p>
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/blocklists/collections/plugins?_expected=1603126502200](https://firefox.settings.services.mozilla.com/v1/buckets/blocklists/collections/plugins?_expected=1603126502200)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/search-default-override-allowlist?_expected=1595254618540](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/search-default-override-allowlist?_expected=1595254618540)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/normandy-recipes-capabilities/changeset?_expected=1615939276941](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/normandy-recipes-capabilities/changeset?_expected=1615939276941)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/blocklists/collections/addons-bloomfilters/changeset?_expected=1615984692436&_since=%221614991099385%22](https://firefox.settings.services.mozilla.com/v1/buckets/blocklists/collections/addons-bloomfilters/changeset?_expected=1615984692436&_since=%221614991099385%22)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/password-recipes?_expected=1600889167888](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/password-recipes?_expected=1600889167888)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/anti-tracking-url-decoration?_expected=1564511755134](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/anti-tracking-url-decoration?_expected=1564511755134)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/cfr-fxa/changeset?_expected=1614634069929](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/cfr-fxa/changeset?_expected=1614634069929)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/monitor/collections/changes/records?collection=whats-new-panel&bucket=main](https://firefox.settings.services.mozilla.com/v1/buckets/monitor/collections/changes/records?collection=whats-new-panel&bucket=main)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `max-age=60`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/search-telemetry?_expected=1613587794383](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/search-telemetry?_expected=1613587794383)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/language-dictionaries?_expected=1569410800356](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/language-dictionaries?_expected=1569410800356)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/monitor/collections/changes/records?collection=message-groups&bucket=main](https://firefox.settings.services.mozilla.com/v1/buckets/monitor/collections/changes/records?collection=message-groups&bucket=main)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `max-age=60`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/monitor/collections/changes/records?collection=cfr&bucket=main](https://firefox.settings.services.mozilla.com/v1/buckets/monitor/collections/changes/records?collection=cfr&bucket=main)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `max-age=60`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615896955616](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615896955616)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/pioneer-study-addons-v1/changeset?_expected=1607042143590](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/pioneer-study-addons-v1/changeset?_expected=1607042143590)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/monitor/collections/changes/records?collection=partitioning-exempt-urls&bucket=main](https://firefox.settings.services.mozilla.com/v1/buckets/monitor/collections/changes/records?collection=partitioning-exempt-urls&bucket=main)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `max-age=60`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/security-state/collections/cert-revocations/changeset?_expected=1615989537021](https://firefox.settings.services.mozilla.com/v1/buckets/security-state/collections/cert-revocations/changeset?_expected=1615989537021)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/public-suffix-list/changeset?_expected=1575468539758](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/public-suffix-list/changeset?_expected=1575468539758)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/partitioning-exempt-urls/changeset?_expected=1592906663254](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/partitioning-exempt-urls/changeset?_expected=1592906663254)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/top-sites/changeset?_expected=1615385045122&_since=%221611838808382%22](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/top-sites/changeset?_expected=1615385045122&_since=%221611838808382%22)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/security-state/collections/onecrl?_expected=1614217822898](https://firefox.settings.services.mozilla.com/v1/buckets/security-state/collections/onecrl?_expected=1614217822898)
  
  
  * Method: `GET`
  
  
  * Parameter: `Cache-Control`
  
  
  * Evidence: `no-cache, no-store`
  
  
  
  
Instances: 34
  
### Solution
<p>Whenever possible ensure the cache-control HTTP header is set with no-cache, no-store, must-revalidate; and that the pragma HTTP header is set with no-cache.</p>
  
### Reference
* https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html#web-content-caching

  
#### CWE Id : 525
  
#### WASC Id : 13
  
#### Source ID : 3

  
  
  
  
### Private IP Disclosure
##### Low (Medium)
  
  
  
  
#### Description
<p>A private IP (such as 10.x.x.x, 172.x.x.x, 192.168.x.x) or an Amazon EC2 private hostname (for example, ip-10-0-56-78) has been found in the HTTP response body. This information might be helpful for further attacks targeting internal systems.</p>
  
  
  
* URL: [https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js](https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `10.01.09.16`
  
  
  
  
Instances: 1
  
### Solution
<p>Remove the private IP address from the HTTP response body.  For comments, use JSP/ASP/PHP comment instead of HTML/JavaScript comment which can be seen by client browsers.</p>
  
### Other information
<p>10.01.09.16</p><p>10.01.09.99</p><p></p>
  
### Reference
* https://tools.ietf.org/html/rfc1918

  
#### CWE Id : 200
  
#### WASC Id : 13
  
#### Source ID : 3

  
  
  
  
### Server Leaks Information via "X-Powered-By" HTTP Response Header Field(s)
##### Low (Medium)
  
  
  
  
#### Description
<p>The web/application server is leaking information via one or more "X-Powered-By" HTTP response headers. Access to such information may facilitate attackers identifying other frameworks/components your web application is reliant upon and the vulnerabilities such components may be subject to.</p>
  
  
  
* URL: [https://localhost:44308/fanclub/comment?storyId=4](https://localhost:44308/fanclub/comment?storyId=4)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44308/FinalImages/1990Cher_icon.png](https://localhost:44308/FinalImages/1990Cher_icon.png)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44308/fanclub/comment?storyId=4](https://localhost:44308/fanclub/comment?storyId=4)
  
  
  * Method: `POST`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44308/home/privacy](https://localhost:44308/home/privacy)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44308/lib/jquery/dist/jquery.min.js](https://localhost:44308/lib/jquery/dist/jquery.min.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44308/fanclub/comment?storyId=3](https://localhost:44308/fanclub/comment?storyId=3)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44308/career/awards](https://localhost:44308/career/awards)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44308/fashion/delete](https://localhost:44308/fashion/delete)
  
  
  * Method: `POST`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44308/Account/Login?ReturnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D4](https://localhost:44308/Account/Login?ReturnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D4)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44308/FinalImages/CherFilm_icon.png](https://localhost:44308/FinalImages/CherFilm_icon.png)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44308/account/login?returnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D4](https://localhost:44308/account/login?returnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D4)
  
  
  * Method: `POST`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44308/FinalImages/1980Cher_icon.png](https://localhost:44308/FinalImages/1980Cher_icon.png)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44308/account/login?returnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D3](https://localhost:44308/account/login?returnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D3)
  
  
  * Method: `POST`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44308/lib/bootstrap/dist/css/bootstrap.min.css](https://localhost:44308/lib/bootstrap/dist/css/bootstrap.min.css)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44308/Account/Login?ReturnUrl=%2Ffanclub%2Fstories](https://localhost:44308/Account/Login?ReturnUrl=%2Ffanclub%2Fstories)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44308/account/login?returnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D2](https://localhost:44308/account/login?returnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D2)
  
  
  * Method: `POST`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44308/fashion](https://localhost:44308/fashion)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44308/lib/bootstrap/dist/js/bootstrap.bundle.min.js](https://localhost:44308/lib/bootstrap/dist/js/bootstrap.bundle.min.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44308/fanclub/stories](https://localhost:44308/fanclub/stories)
  
  
  * Method: `POST`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
* URL: [https://localhost:44308/FinalImages/logo1.jpg](https://localhost:44308/FinalImages/logo1.jpg)
  
  
  * Method: `GET`
  
  
  * Evidence: `X-Powered-By: ASP.NET`
  
  
  
  
Instances: 61
  
### Solution
<p>Ensure that your web server, application server, load balancer, etc. is configured to suppress "X-Powered-By" headers.</p>
  
### Reference
* http://blogs.msdn.com/b/varunm/archive/2013/04/23/remove-unwanted-http-response-headers.aspx
* http://www.troyhunt.com/2012/02/shhh-dont-let-your-response-headers.html

  
#### CWE Id : 200
  
#### WASC Id : 13
  
#### Source ID : 3

  
  
  
  
### X-Content-Type-Options Header Missing
##### Low (Medium)
  
  
  
  
#### Description
<p>The Anti-MIME-Sniffing header X-Content-Type-Options was not set to 'nosniff'. This allows older versions of Internet Explorer and Chrome to perform MIME-sniffing on the response body, potentially causing the response body to be interpreted and displayed as a content type other than the declared content type. Current (early 2014) and legacy versions of Firefox will use the declared content type (if one is set), rather than performing MIME-sniffing.</p>
  
  
  
* URL: [https://ftp.mozilla.org/pub/system-addons/reset-search-defaults/reset-search-defaults@mozilla.com-1.0.5-signed.xpi](https://ftp.mozilla.org/pub/system-addons/reset-search-defaults/reset-search-defaults@mozilla.com-1.0.5-signed.xpi)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
Instances: 1
  
### Solution
<p>Ensure that the application/web server sets the Content-Type header appropriately, and that it sets the X-Content-Type-Options header to 'nosniff' for all web pages.</p><p>If possible, ensure that the end user uses a standards-compliant and modern web browser that does not perform MIME-sniffing at all, or that can be directed by the web application/web server to not perform MIME-sniffing.</p>
  
### Other information
<p>This issue still applies to error type pages (401, 403, 500, etc.) as those pages are often still affected by injection issues, in which case there is still concern for browsers sniffing pages away from their actual content type.</p><p>At "High" threshold this scan rule will not alert on client or server error responses.</p>
  
### Reference
* http://msdn.microsoft.com/en-us/library/ie/gg622941%28v=vs.85%29.aspx
* https://owasp.org/www-community/Security_Headers

  
#### CWE Id : 16
  
#### WASC Id : 15
  
#### Source ID : 3

  
  
  
  
### X-Content-Type-Options Header Missing
##### Low (Medium)
  
  
  
  
#### Description
<p>The Anti-MIME-Sniffing header X-Content-Type-Options was not set to 'nosniff'. This allows older versions of Internet Explorer and Chrome to perform MIME-sniffing on the response body, potentially causing the response body to be interpreted and displayed as a content type other than the declared content type. Current (early 2014) and legacy versions of Firefox will use the declared content type (if one is set), rather than performing MIME-sniffing.</p>
  
  
  
* URL: [https://snippets.cdn.mozilla.net/us-west/bundles-pregen/Firefox/en-us/default.json](https://snippets.cdn.mozilla.net/us-west/bundles-pregen/Firefox/en-us/default.json)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
Instances: 1
  
### Solution
<p>Ensure that the application/web server sets the Content-Type header appropriately, and that it sets the X-Content-Type-Options header to 'nosniff' for all web pages.</p><p>If possible, ensure that the end user uses a standards-compliant and modern web browser that does not perform MIME-sniffing at all, or that can be directed by the web application/web server to not perform MIME-sniffing.</p>
  
### Other information
<p>This issue still applies to error type pages (401, 403, 500, etc.) as those pages are often still affected by injection issues, in which case there is still concern for browsers sniffing pages away from their actual content type.</p><p>At "High" threshold this scan rule will not alert on client or server error responses.</p>
  
### Reference
* http://msdn.microsoft.com/en-us/library/ie/gg622941%28v=vs.85%29.aspx
* https://owasp.org/www-community/Security_Headers

  
#### CWE Id : 16
  
#### WASC Id : 15
  
#### Source ID : 3

  
  
  
  
### X-Content-Type-Options Header Missing
##### Low (Medium)
  
  
  
  
#### Description
<p>The Anti-MIME-Sniffing header X-Content-Type-Options was not set to 'nosniff'. This allows older versions of Internet Explorer and Chrome to perform MIME-sniffing on the response body, potentially causing the response body to be interpreted and displayed as a content type other than the declared content type. Current (early 2014) and legacy versions of Firefox will use the declared content type (if one is set), rather than performing MIME-sniffing.</p>
  
  
  
* URL: [https://content-signature-2.cdn.mozilla.net/chains/remote-settings.content-signature.mozilla.org-2021-05-02-15-04-19.chain](https://content-signature-2.cdn.mozilla.net/chains/remote-settings.content-signature.mozilla.org-2021-05-02-15-04-19.chain)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://content-signature-2.cdn.mozilla.net/chains/onecrl.content-signature.mozilla.org-2021-05-02-15-04-07.chain](https://content-signature-2.cdn.mozilla.net/chains/onecrl.content-signature.mozilla.org-2021-05-02-15-04-07.chain)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://content-signature-2.cdn.mozilla.net/chains/pinning-preload.content-signature.mozilla.org-2021-05-02-15-04-13.chain](https://content-signature-2.cdn.mozilla.net/chains/pinning-preload.content-signature.mozilla.org-2021-05-02-15-04-13.chain)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
Instances: 3
  
### Solution
<p>Ensure that the application/web server sets the Content-Type header appropriately, and that it sets the X-Content-Type-Options header to 'nosniff' for all web pages.</p><p>If possible, ensure that the end user uses a standards-compliant and modern web browser that does not perform MIME-sniffing at all, or that can be directed by the web application/web server to not perform MIME-sniffing.</p>
  
### Other information
<p>This issue still applies to error type pages (401, 403, 500, etc.) as those pages are often still affected by injection issues, in which case there is still concern for browsers sniffing pages away from their actual content type.</p><p>At "High" threshold this scan rule will not alert on client or server error responses.</p>
  
### Reference
* http://msdn.microsoft.com/en-us/library/ie/gg622941%28v=vs.85%29.aspx
* https://owasp.org/www-community/Security_Headers

  
#### CWE Id : 16
  
#### WASC Id : 15
  
#### Source ID : 3

  
  
  
  
### X-Content-Type-Options Header Missing
##### Low (Medium)
  
  
  
  
#### Description
<p>The Anti-MIME-Sniffing header X-Content-Type-Options was not set to 'nosniff'. This allows older versions of Internet Explorer and Chrome to perform MIME-sniffing on the response body, potentially causing the response body to be interpreted and displayed as a content type other than the declared content type. Current (early 2014) and legacy versions of Firefox will use the declared content type (if one is set), rather than performing MIME-sniffing.</p>
  
  
  
* URL: [https://localhost:44308/FinalImages/CherFilm_icon.png](https://localhost:44308/FinalImages/CherFilm_icon.png)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://localhost:44308/fashion](https://localhost:44308/fashion)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://localhost:44308/account/login?returnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D4](https://localhost:44308/account/login?returnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D4)
  
  
  * Method: `POST`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://localhost:44308/fanclub/comment?storyId=4](https://localhost:44308/fanclub/comment?storyId=4)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://localhost:44308/lib/bootstrap/dist/css/bootstrap.min.css](https://localhost:44308/lib/bootstrap/dist/css/bootstrap.min.css)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://localhost:44308/career/awards](https://localhost:44308/career/awards)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://localhost:44308/account/login?returnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D3](https://localhost:44308/account/login?returnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D3)
  
  
  * Method: `POST`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://localhost:44308/lib/jquery/dist/jquery.min.js](https://localhost:44308/lib/jquery/dist/jquery.min.js)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://localhost:44308/career/albums](https://localhost:44308/career/albums)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://localhost:44308/account/login?returnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D2](https://localhost:44308/account/login?returnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D2)
  
  
  * Method: `POST`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://localhost:44308/FinalImages/1980Cher_icon.png](https://localhost:44308/FinalImages/1980Cher_icon.png)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://localhost:44308/Account/Login?ReturnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D2](https://localhost:44308/Account/Login?ReturnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D2)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://localhost:44308/career/tv](https://localhost:44308/career/tv)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://localhost:44308/account/login?returnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D1](https://localhost:44308/account/login?returnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D1)
  
  
  * Method: `POST`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://localhost:44308/FinalImages/CherAlbums_icon.png](https://localhost:44308/FinalImages/CherAlbums_icon.png)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://localhost:44308/Account/Login?ReturnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D1](https://localhost:44308/Account/Login?ReturnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D1)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://localhost:44308/FinalImages/HomeCher.jpg](https://localhost:44308/FinalImages/HomeCher.jpg)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://localhost:44308/fashion/sixties](https://localhost:44308/fashion/sixties)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://localhost:44308/account/login?returnUrl=%2Ffanclub%2Fstories](https://localhost:44308/account/login?returnUrl=%2Ffanclub%2Fstories)
  
  
  * Method: `POST`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://localhost:44308/Account/Login?ReturnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D4](https://localhost:44308/Account/Login?ReturnUrl=%2Ffanclub%2Fcomment%3FstoryId%3D4)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
Instances: 52
  
### Solution
<p>Ensure that the application/web server sets the Content-Type header appropriately, and that it sets the X-Content-Type-Options header to 'nosniff' for all web pages.</p><p>If possible, ensure that the end user uses a standards-compliant and modern web browser that does not perform MIME-sniffing at all, or that can be directed by the web application/web server to not perform MIME-sniffing.</p>
  
### Other information
<p>This issue still applies to error type pages (401, 403, 500, etc.) as those pages are often still affected by injection issues, in which case there is still concern for browsers sniffing pages away from their actual content type.</p><p>At "High" threshold this scan rule will not alert on client or server error responses.</p>
  
### Reference
* http://msdn.microsoft.com/en-us/library/ie/gg622941%28v=vs.85%29.aspx
* https://owasp.org/www-community/Security_Headers

  
#### CWE Id : 16
  
#### WASC Id : 15
  
#### Source ID : 3

  
  
  
  
### X-Content-Type-Options Header Missing
##### Low (Medium)
  
  
  
  
#### Description
<p>The Anti-MIME-Sniffing header X-Content-Type-Options was not set to 'nosniff'. This allows older versions of Internet Explorer and Chrome to perform MIME-sniffing on the response body, potentially causing the response body to be interpreted and displayed as a content type other than the declared content type. Current (early 2014) and legacy versions of Firefox will use the declared content type (if one is set), rather than performing MIME-sniffing.</p>
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/social-tracking-protection-linkedin-digest256/86.0/1611617625](https://tracking-protection.cdn.mozilla.net/social-tracking-protection-linkedin-digest256/86.0/1611617625)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/block-flash-digest256/1604686195](https://tracking-protection.cdn.mozilla.net/block-flash-digest256/1604686195)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/analytics-track-digest256/86.0/1611617625](https://tracking-protection.cdn.mozilla.net/analytics-track-digest256/86.0/1611617625)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/base-fingerprinting-track-digest256/86.0/1611617625](https://tracking-protection.cdn.mozilla.net/base-fingerprinting-track-digest256/86.0/1611617625)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/except-flashallow-digest256/1490633678](https://tracking-protection.cdn.mozilla.net/except-flashallow-digest256/1490633678)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/ads-track-digest256/86.0/1611617625](https://tracking-protection.cdn.mozilla.net/ads-track-digest256/86.0/1611617625)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/except-flashsubdoc-digest256/1517935265](https://tracking-protection.cdn.mozilla.net/except-flashsubdoc-digest256/1517935265)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/mozstd-trackwhite-digest256/86.0/1611617625](https://tracking-protection.cdn.mozilla.net/mozstd-trackwhite-digest256/86.0/1611617625)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/social-tracking-protection-facebook-digest256/86.0/1611617625](https://tracking-protection.cdn.mozilla.net/social-tracking-protection-facebook-digest256/86.0/1611617625)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/social-track-digest256/86.0/1611617625](https://tracking-protection.cdn.mozilla.net/social-track-digest256/86.0/1611617625)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/block-flashsubdoc-digest256/1604686195](https://tracking-protection.cdn.mozilla.net/block-flashsubdoc-digest256/1604686195)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/content-track-digest256/86.0/1611617625](https://tracking-protection.cdn.mozilla.net/content-track-digest256/86.0/1611617625)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/except-flash-digest256/1604686195](https://tracking-protection.cdn.mozilla.net/except-flash-digest256/1604686195)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/allow-flashallow-digest256/1490633678](https://tracking-protection.cdn.mozilla.net/allow-flashallow-digest256/1490633678)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/base-cryptomining-track-digest256/86.0/1611617625](https://tracking-protection.cdn.mozilla.net/base-cryptomining-track-digest256/86.0/1611617625)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/social-tracking-protection-twitter-digest256/86.0/1611617625](https://tracking-protection.cdn.mozilla.net/social-tracking-protection-twitter-digest256/86.0/1611617625)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/google-trackwhite-digest256/86.0/1611617625](https://tracking-protection.cdn.mozilla.net/google-trackwhite-digest256/86.0/1611617625)
  
  
  * Method: `GET`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
Instances: 17
  
### Solution
<p>Ensure that the application/web server sets the Content-Type header appropriately, and that it sets the X-Content-Type-Options header to 'nosniff' for all web pages.</p><p>If possible, ensure that the end user uses a standards-compliant and modern web browser that does not perform MIME-sniffing at all, or that can be directed by the web application/web server to not perform MIME-sniffing.</p>
  
### Other information
<p>This issue still applies to error type pages (401, 403, 500, etc.) as those pages are often still affected by injection issues, in which case there is still concern for browsers sniffing pages away from their actual content type.</p><p>At "High" threshold this scan rule will not alert on client or server error responses.</p>
  
### Reference
* http://msdn.microsoft.com/en-us/library/ie/gg622941%28v=vs.85%29.aspx
* https://owasp.org/www-community/Security_Headers

  
#### CWE Id : 16
  
#### WASC Id : 15
  
#### Source ID : 3

  
  
  
  
### X-Content-Type-Options Header Missing
##### Low (Medium)
  
  
  
  
#### Description
<p>The Anti-MIME-Sniffing header X-Content-Type-Options was not set to 'nosniff'. This allows older versions of Internet Explorer and Chrome to perform MIME-sniffing on the response body, potentially causing the response body to be interpreted and displayed as a content type other than the declared content type. Current (early 2014) and legacy versions of Firefox will use the declared content type (if one is set), rather than performing MIME-sniffing.</p>
  
  
  
* URL: [https://shavar.services.mozilla.com/downloads?client=navclient-auto-ffox&appver=86.0&pver=2.2](https://shavar.services.mozilla.com/downloads?client=navclient-auto-ffox&appver=86.0&pver=2.2)
  
  
  * Method: `POST`
  
  
  * Parameter: `X-Content-Type-Options`
  
  
  
  
Instances: 1
  
### Solution
<p>Ensure that the application/web server sets the Content-Type header appropriately, and that it sets the X-Content-Type-Options header to 'nosniff' for all web pages.</p><p>If possible, ensure that the end user uses a standards-compliant and modern web browser that does not perform MIME-sniffing at all, or that can be directed by the web application/web server to not perform MIME-sniffing.</p>
  
### Other information
<p>This issue still applies to error type pages (401, 403, 500, etc.) as those pages are often still affected by injection issues, in which case there is still concern for browsers sniffing pages away from their actual content type.</p><p>At "High" threshold this scan rule will not alert on client or server error responses.</p>
  
### Reference
* http://msdn.microsoft.com/en-us/library/ie/gg622941%28v=vs.85%29.aspx
* https://owasp.org/www-community/Security_Headers

  
#### CWE Id : 16
  
#### WASC Id : 15
  
#### Source ID : 3

  
  
  
  
### Charset Mismatch 
##### Informational (Low)
  
  
  
  
#### Description
<p>This check identifies responses where the HTTP Content-Type header declares a charset different from the charset defined by the body of the HTML or XML. When there's a charset mismatch between the HTTP header and content body Web browsers can be forced into an undesirable content-sniffing mode to determine the content's correct character set.</p><p></p><p>An attacker could manipulate content on the page to be interpreted in an encoding of their choice. For example, if an attacker can control content at the beginning of the page, they could inject script using UTF-7 encoded text and manipulate some browsers into interpreting that text.</p>
  
  
  
* URL: [https://aus5.mozilla.org/update/3/SystemAddons/86.0.1/20210310152336/WINNT_x86_64-msvc-x64/en-US/release/Windows_NT%2010.0.0.0.19041.867%20(x64)/default/default/update.xml](https://aus5.mozilla.org/update/3/SystemAddons/86.0.1/20210310152336/WINNT_x86_64-msvc-x64/en-US/release/Windows_NT%2010.0.0.0.19041.867%20(x64)/default/default/update.xml)
  
  
  * Method: `GET`
  
  
  
  
Instances: 1
  
### Solution
<p>Force UTF-8 for all text content in both the HTTP header and meta tags in HTML or encoding declarations in XML.</p>
  
### Other information
<p>There was a charset mismatch between the HTTP Header and the XML encoding declaration: [utf-8] and [null] do not match.</p>
  
### Reference
* http://code.google.com/p/browsersec/wiki/Part2#Character_set_handling_and_detection

  
#### CWE Id : 16
  
#### WASC Id : 15
  
#### Source ID : 3

  
  
  
  
### Information Disclosure - Sensitive Information in URL
##### Informational (Medium)
  
  
  
  
#### Description
<p>The request appeared to contain sensitive information leaked in the URL. This can violate PCI and most organizational compliance policies. You can configure the list of strings for this check to add or remove values specific to your environment.</p>
  
  
  
* URL: [https://versioncheck.addons.mozilla.org/update/VersionCheck.php?reqVersion=2&id=reset-search-defaults@mozilla.com&version=1.0.5&maxAppVersion=86.0&status=userEnabled,incompatible&appID=%7Bec8030f7-c20a-464f-9b0e-13a3a9e97384%7D&appVersion=86.0.1&appOS=WINNT&appABI=x86_64-msvc&locale=en-US&currentAppVersion=86.0.1&updateType=49&compatMode=normal](https://versioncheck.addons.mozilla.org/update/VersionCheck.php?reqVersion=2&id=reset-search-defaults@mozilla.com&version=1.0.5&maxAppVersion=86.0&status=userEnabled,incompatible&appID=%7Bec8030f7-c20a-464f-9b0e-13a3a9e97384%7D&appVersion=86.0.1&appOS=WINNT&appABI=x86_64-msvc&locale=en-US&currentAppVersion=86.0.1&updateType=49&compatMode=normal)
  
  
  * Method: `GET`
  
  
  * Parameter: `id`
  
  
  * Evidence: `reset-search-defaults@mozilla.com`
  
  
  
  
Instances: 1
  
### Solution
<p>Do not pass sensitive information in URIs.</p>
  
### Other information
<p>The URL contains email address(es).</p>
  
### Reference
* 

  
#### CWE Id : 200
  
#### WASC Id : 13
  
#### Source ID : 3

  
  
  
  
### Information Disclosure - Suspicious Comments
##### Informational (Medium)
  
  
  
  
#### Description
<p>The response appears to contain suspicious comments which may help an attacker. Note: Matches made within script blocks or files are against the entire content not only comments.</p>
  
  
  
* URL: [https://localhost:44308/account/register](https://localhost:44308/account/register)
  
  
  * Method: `GET`
  
  
  * Evidence: `where`
  
  
  
  
* URL: [https://localhost:44308/account/register](https://localhost:44308/account/register)
  
  
  * Method: `POST`
  
  
  * Evidence: `where`
  
  
  
  
Instances: 2
  
### Solution
<p>Remove all comments that return information that may help an attacker and fix any underlying problems they refer to.</p>
  
### Other information
<p>The following pattern was used: \bWHERE\b and was detected in the element starting with: "<!-- Per GA the validation both work in and outside the form, it just changes where the error shows up -->", see evidence field for the suspicious comment/snippet.</p>
  
### Reference
* 

  
#### CWE Id : 200
  
#### WASC Id : 13
  
#### Source ID : 3

  
  
  
  
### Information Disclosure - Suspicious Comments
##### Informational (Low)
  
  
  
  
#### Description
<p>The response appears to contain suspicious comments which may help an attacker. Note: Matches made within script blocks or files are against the entire content not only comments.</p>
  
  
  
* URL: [https://www.google.com/js/bg/GHE3nmVSkstokqzvGe9ZJ60ZxJZF7B7kK12a7dcDHRY.js](https://www.google.com/js/bg/GHE3nmVSkstokqzvGe9ZJ60ZxJZF7B7kK12a7dcDHRY.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `db`
  
  
  
  
Instances: 1
  
### Solution
<p>Remove all comments that return information that may help an attacker and fix any underlying problems they refer to.</p>
  
### Other information
<p>The following pattern was used: \bDB\b and was detected in the element starting with: "(function(){var c=function(X,h){if((X=(h=null,K.trustedTypes),!X)||!X.createPolicy)return h;try{h=X.createPolicy("bg",{createHTM", see evidence field for the suspicious comment/snippet.</p>
  
### Reference
* 

  
#### CWE Id : 200
  
#### WASC Id : 13
  
#### Source ID : 3

  
  
  
  
### Information Disclosure - Suspicious Comments
##### Informational (Low)
  
  
  
  
#### Description
<p>The response appears to contain suspicious comments which may help an attacker. Note: Matches made within script blocks or files are against the entire content not only comments.</p>
  
  
  
* URL: [https://www.youtube.com/s/player/223a7479/www-embed-player.vflset/www-embed-player.js](https://www.youtube.com/s/player/223a7479/www-embed-player.vflset/www-embed-player.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `query`
  
  
  
  
* URL: [https://www.youtube.com/s/player/223a7479/www-embed-player.vflset/www-embed-player.js](https://www.youtube.com/s/player/223a7479/www-embed-player.vflset/www-embed-player.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `db`
  
  
  
  
* URL: [https://www.youtube.com/s/player/223a7479/www-embed-player.vflset/www-embed-player.js](https://www.youtube.com/s/player/223a7479/www-embed-player.vflset/www-embed-player.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `from`
  
  
  
  
* URL: [https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js](https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `user`
  
  
  
  
* URL: [https://www.youtube.com/embed/qLq6k6Ckafg](https://www.youtube.com/embed/qLq6k6Ckafg)
  
  
  * Method: `GET`
  
  
  * Evidence: `user`
  
  
  
  
* URL: [https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/remote.js](https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/remote.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `from`
  
  
  
  
* URL: [https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js](https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `username`
  
  
  
  
* URL: [https://www.youtube.com/s/player/223a7479/fetch-polyfill.vflset/fetch-polyfill.js](https://www.youtube.com/s/player/223a7479/fetch-polyfill.vflset/fetch-polyfill.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `FROM`
  
  
  
  
* URL: [https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js](https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `admin`
  
  
  
  
* URL: [https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/remote.js](https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/remote.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `Db`
  
  
  
  
* URL: [https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/remote.js](https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/remote.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `user`
  
  
  
  
* URL: [https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js](https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `SELECT`
  
  
  
  
* URL: [https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js](https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `query`
  
  
  
  
* URL: [https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js](https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `dB`
  
  
  
  
* URL: [https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js](https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `from`
  
  
  
  
* URL: [https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js](https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `later`
  
  
  
  
* URL: [https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js](https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `where`
  
  
  
  
* URL: [https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/embed.js](https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/embed.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `from`
  
  
  
  
* URL: [https://www.youtube.com/s/player/223a7479/www-embed-player.vflset/www-embed-player.js](https://www.youtube.com/s/player/223a7479/www-embed-player.vflset/www-embed-player.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `user`
  
  
  
  
Instances: 19
  
### Solution
<p>Remove all comments that return information that may help an attacker and fix any underlying problems they refer to.</p>
  
### Other information
<p>The following pattern was used: \bQUERY\b and was detected 6 times, the first in the element starting with: ";var Nf=/^[\w.]*$/,Of={q:!0,search_query:!0};function Pf(a,b){for(var c=a.split(b),d={},e=0,f=c.length;e<f;e++){var g=c[e].split", see evidence field for the suspicious comment/snippet.</p>
  
### Reference
* 

  
#### CWE Id : 200
  
#### WASC Id : 13
  
#### Source ID : 3

  
  
  
  
### Information Disclosure - Suspicious Comments
##### Informational (Low)
  
  
  
  
#### Description
<p>The response appears to contain suspicious comments which may help an attacker. Note: Matches made within script blocks or files are against the entire content not only comments.</p>
  
  
  
* URL: [https://localhost:44308/lib/bootstrap/dist/js/bootstrap.bundle.min.js](https://localhost:44308/lib/bootstrap/dist/js/bootstrap.bundle.min.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `from`
  
  
  
  
* URL: [https://localhost:44308/lib/jquery/dist/jquery.min.js](https://localhost:44308/lib/jquery/dist/jquery.min.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `username`
  
  
  
  
Instances: 2
  
### Solution
<p>Remove all comments that return information that may help an attacker and fix any underlying problems they refer to.</p>
  
### Other information
<p>The following pattern was used: \bFROM\b and was detected in the element starting with: "!function(t,e){"object"==typeof exports&&"undefined"!=typeof module?e(exports,require("jquery")):"function"==typeof define&&defi", see evidence field for the suspicious comment/snippet.</p>
  
### Reference
* 

  
#### CWE Id : 200
  
#### WASC Id : 13
  
#### Source ID : 3

  
  
  
  
### Loosely Scoped Cookie
##### Informational (Low)
  
  
  
  
#### Description
<p>Cookies can be scoped by domain or path. This check is only concerned with domain scope.The domain scope applied to a cookie determines which domains can access it. For example, a cookie can be scoped strictly to a subdomain e.g. www.nottrusted.com, or loosely scoped to a parent domain e.g. nottrusted.com. In the latter case, any subdomain of nottrusted.com can access the cookie. Loosely scoped cookies are common in mega-applications like google.com and live.com. Cookies set from a subdomain like app.foo.bar are transmitted only to that domain by the browser. However, cookies scoped to a parent-level domain may be transmitted to the parent, or any subdomain of the parent.</p>
  
  
  
* URL: [https://googleads.g.doubleclick.net/pagead/id](https://googleads.g.doubleclick.net/pagead/id)
  
  
  * Method: `GET`
  
  
  
  
* URL: [https://googleads.g.doubleclick.net/pagead/id?slf_rd=1](https://googleads.g.doubleclick.net/pagead/id?slf_rd=1)
  
  
  * Method: `GET`
  
  
  
  
Instances: 2
  
### Solution
<p>Always scope cookies to a FQDN (Fully Qualified Domain Name).</p>
  
### Other information
<p>The origin domain used for comparison was: </p><p>googleads.g.doubleclick.net</p><p>test_cookie=CheckForPermission</p><p></p>
  
### Reference
* https://tools.ietf.org/html/rfc6265#section-4.1
* https://owasp.org/www-project-web-security-testing-guide/v41/4-Web_Application_Security_Testing/06-Session_Management_Testing/02-Testing_for_Cookies_Attributes.html
* http://code.google.com/p/browsersec/wiki/Part2#Same-origin_policy_for_cookies

  
#### CWE Id : 565
  
#### WASC Id : 15
  
#### Source ID : 3

  
  
  
  
### Loosely Scoped Cookie
##### Informational (Low)
  
  
  
  
#### Description
<p>Cookies can be scoped by domain or path. This check is only concerned with domain scope.The domain scope applied to a cookie determines which domains can access it. For example, a cookie can be scoped strictly to a subdomain e.g. www.nottrusted.com, or loosely scoped to a parent domain e.g. nottrusted.com. In the latter case, any subdomain of nottrusted.com can access the cookie. Loosely scoped cookies are common in mega-applications like google.com and live.com. Cookies set from a subdomain like app.foo.bar are transmitted only to that domain by the browser. However, cookies scoped to a parent-level domain may be transmitted to the parent, or any subdomain of the parent.</p>
  
  
  
* URL: [https://www.youtube.com/embed/qLq6k6Ckafg](https://www.youtube.com/embed/qLq6k6Ckafg)
  
  
  * Method: `GET`
  
  
  
  
Instances: 1
  
### Solution
<p>Always scope cookies to a FQDN (Fully Qualified Domain Name).</p>
  
### Other information
<p>The origin domain used for comparison was: </p><p>www.youtube.com</p><p>YSC=D3celTnc9P8</p><p>VISITOR_INFO1_LIVE=bvHrrQRJ4Xc</p><p></p>
  
### Reference
* https://tools.ietf.org/html/rfc6265#section-4.1
* https://owasp.org/www-project-web-security-testing-guide/v41/4-Web_Application_Security_Testing/06-Session_Management_Testing/02-Testing_for_Cookies_Attributes.html
* http://code.google.com/p/browsersec/wiki/Part2#Same-origin_policy_for_cookies

  
#### CWE Id : 565
  
#### WASC Id : 15
  
#### Source ID : 3

  
  
  
  
### Loosely Scoped Cookie
##### Informational (Low)
  
  
  
  
#### Description
<p>Cookies can be scoped by domain or path. This check is only concerned with domain scope.The domain scope applied to a cookie determines which domains can access it. For example, a cookie can be scoped strictly to a subdomain e.g. www.nottrusted.com, or loosely scoped to a parent domain e.g. nottrusted.com. In the latter case, any subdomain of nottrusted.com can access the cookie. Loosely scoped cookies are common in mega-applications like google.com and live.com. Cookies set from a subdomain like app.foo.bar are transmitted only to that domain by the browser. However, cookies scoped to a parent-level domain may be transmitted to the parent, or any subdomain of the parent.</p>
  
  
  
* URL: [https://localhost:44308/account/register](https://localhost:44308/account/register)
  
  
  * Method: `POST`
  
  
  
  
* URL: [https://localhost:44308/account/register](https://localhost:44308/account/register)
  
  
  * Method: `GET`
  
  
  
  
* URL: [https://localhost:44308/fashion/delete](https://localhost:44308/fashion/delete)
  
  
  * Method: `POST`
  
  
  
  
* URL: [https://localhost:44308/account/register](https://localhost:44308/account/register)
  
  
  * Method: `GET`
  
  
  
  
Instances: 4
  
### Solution
<p>Always scope cookies to a FQDN (Fully Qualified Domain Name).</p>
  
### Other information
<p>The origin domain used for comparison was: </p><p>localhost</p><p>.AspNetCore.Identity.Application=CfDJ8LBJaPicz1hFkjueW89XL3SZjepI1Kx6Of_FZQut_QKaZWHMKYeQRg2eYPbQlyvhP-5_DZ4Srstf6hXEJy-tDymbyRAamFE6MJcV7mKHNjyL6nu0__nP7YTwG5r4VuB5aeqKv__xO8uGuVYRB_IUdDqgy4FNwLbiLDviE08PAj8JcY7LXw31trq423RFKOSB3CyIau4wRa5o_TA4LL0tSI_wEJz4qqptCDuOVJTTNZyAeLykI0fK-6H-uxpSfacntSGPGAorv_4-iNxYrqzMv0QUis7mQ_CQ925S1nMv0lcsVgNIMXzfCzVtNt6PqonLmTw3cvl0RsfAk5VoueOwZtH7SDnqWj_oAYSIwLZHNaX8u8gb6HL7l36Fu3aAfMC0Lt8gIfpICepis79jB5WOl939se-9x79D7zJmiqdnubr-kHbBh4SyxScOb5fnzdGhk5KuJnpe3LGiKRZsHvXSD4bXO6nGU9sgUhmMZSx4hhCu9pEp6FfPxa1oT1jUj0uMfbpzvfbEDT_7W2GxyH-6WrDVNSmruKgtZwCEevTkiKgYmqVA6LLplj3nl0Qj6Dl9ZMxlNfn4_YBT4jPIFnDpXd0</p><p></p>
  
### Reference
* https://tools.ietf.org/html/rfc6265#section-4.1
* https://owasp.org/www-project-web-security-testing-guide/v41/4-Web_Application_Security_Testing/06-Session_Management_Testing/02-Testing_for_Cookies_Attributes.html
* http://code.google.com/p/browsersec/wiki/Part2#Same-origin_policy_for_cookies

  
#### CWE Id : 565
  
#### WASC Id : 15
  
#### Source ID : 3

  
  
  
  
### Timestamp Disclosure - Unix
##### Informational (Low)
  
  
  
  
#### Description
<p>A timestamp was disclosed by the application/web server - Unix</p>
  
  
  
* URL: [https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js](https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `166824318`
  
  
  
  
* URL: [https://www.youtube.com/embed/qLq6k6Ckafg](https://www.youtube.com/embed/qLq6k6Ckafg)
  
  
  * Method: `GET`
  
  
  * Evidence: `24014442`
  
  
  
  
* URL: [https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js](https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `23916106`
  
  
  
  
* URL: [https://www.youtube.com/embed/qLq6k6Ckafg](https://www.youtube.com/embed/qLq6k6Ckafg)
  
  
  * Method: `GET`
  
  
  * Evidence: `24012099`
  
  
  
  
* URL: [https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js](https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `530742520`
  
  
  
  
* URL: [https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js](https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `357149030`
  
  
  
  
* URL: [https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js](https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `1709208261`
  
  
  
  
* URL: [https://www.youtube.com/s/player/223a7479/www-player-webp.css](https://www.youtube.com/s/player/223a7479/www-player-webp.css)
  
  
  * Method: `GET`
  
  
  * Evidence: `0909090909`
  
  
  
  
* URL: [https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js](https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `2139516950`
  
  
  
  
* URL: [https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js](https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `1541459225`
  
  
  
  
* URL: [https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js](https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `1836279920`
  
  
  
  
* URL: [https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js](https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `1839030562`
  
  
  
  
* URL: [https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js](https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `1272893353`
  
  
  
  
* URL: [https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js](https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `268435456`
  
  
  
  
* URL: [https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js](https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `203733812`
  
  
  
  
* URL: [https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js](https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `1836019574`
  
  
  
  
* URL: [https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js](https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `568446438`
  
  
  
  
* URL: [https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js](https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `604807628`
  
  
  
  
* URL: [https://www.youtube.com/embed/qLq6k6Ckafg](https://www.youtube.com/embed/qLq6k6Ckafg)
  
  
  * Method: `GET`
  
  
  * Evidence: `20210317`
  
  
  
  
* URL: [https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js](https://www.youtube.com/s/player/223a7479/player_ias.vflset/en_US/base.js)
  
  
  * Method: `GET`
  
  
  * Evidence: `1126891415`
  
  
  
  
Instances: 220
  
### Solution
<p>Manually confirm that the timestamp data is not sensitive, and that the data cannot be aggregated to disclose exploitable patterns.</p>
  
### Other information
<p>166824318, which evaluates to: 1975-04-15 13:05:18</p>
  
### Reference
* http://projects.webappsec.org/w/page/13246936/Information%20Leakage

  
#### CWE Id : 200
  
#### WASC Id : 13
  
#### Source ID : 3

  
  
  
  
### Timestamp Disclosure - Unix
##### Informational (Low)
  
  
  
  
#### Description
<p>A timestamp was disclosed by the application/web server - Unix</p>
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/mozstd-trackwhite-digest256/86.0/1611617625](https://tracking-protection.cdn.mozilla.net/mozstd-trackwhite-digest256/86.0/1611617625)
  
  
  * Method: `GET`
  
  
  * Evidence: `1611617625`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/google-trackwhite-digest256/86.0/1611617625](https://tracking-protection.cdn.mozilla.net/google-trackwhite-digest256/86.0/1611617625)
  
  
  * Method: `GET`
  
  
  * Evidence: `1611617625`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/social-tracking-protection-facebook-digest256/86.0/1611617625](https://tracking-protection.cdn.mozilla.net/social-tracking-protection-facebook-digest256/86.0/1611617625)
  
  
  * Method: `GET`
  
  
  * Evidence: `1611617625`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/social-tracking-protection-twitter-digest256/86.0/1611617625](https://tracking-protection.cdn.mozilla.net/social-tracking-protection-twitter-digest256/86.0/1611617625)
  
  
  * Method: `GET`
  
  
  * Evidence: `1611617625`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/content-track-digest256/86.0/1611617625](https://tracking-protection.cdn.mozilla.net/content-track-digest256/86.0/1611617625)
  
  
  * Method: `GET`
  
  
  * Evidence: `1611617625`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/block-flashsubdoc-digest256/1604686195](https://tracking-protection.cdn.mozilla.net/block-flashsubdoc-digest256/1604686195)
  
  
  * Method: `GET`
  
  
  * Evidence: `1604686195`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/allow-flashallow-digest256/1490633678](https://tracking-protection.cdn.mozilla.net/allow-flashallow-digest256/1490633678)
  
  
  * Method: `GET`
  
  
  * Evidence: `1490633678`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/social-track-digest256/86.0/1611617625](https://tracking-protection.cdn.mozilla.net/social-track-digest256/86.0/1611617625)
  
  
  * Method: `GET`
  
  
  * Evidence: `1611617625`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/except-flashallow-digest256/1490633678](https://tracking-protection.cdn.mozilla.net/except-flashallow-digest256/1490633678)
  
  
  * Method: `GET`
  
  
  * Evidence: `1490633678`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/except-flash-digest256/1604686195](https://tracking-protection.cdn.mozilla.net/except-flash-digest256/1604686195)
  
  
  * Method: `GET`
  
  
  * Evidence: `1604686195`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/except-flashsubdoc-digest256/1517935265](https://tracking-protection.cdn.mozilla.net/except-flashsubdoc-digest256/1517935265)
  
  
  * Method: `GET`
  
  
  * Evidence: `1517935265`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/base-fingerprinting-track-digest256/86.0/1611617625](https://tracking-protection.cdn.mozilla.net/base-fingerprinting-track-digest256/86.0/1611617625)
  
  
  * Method: `GET`
  
  
  * Evidence: `1611617625`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/social-tracking-protection-linkedin-digest256/86.0/1611617625](https://tracking-protection.cdn.mozilla.net/social-tracking-protection-linkedin-digest256/86.0/1611617625)
  
  
  * Method: `GET`
  
  
  * Evidence: `1611617625`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/ads-track-digest256/86.0/1611617625](https://tracking-protection.cdn.mozilla.net/ads-track-digest256/86.0/1611617625)
  
  
  * Method: `GET`
  
  
  * Evidence: `1611617625`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/block-flash-digest256/1604686195](https://tracking-protection.cdn.mozilla.net/block-flash-digest256/1604686195)
  
  
  * Method: `GET`
  
  
  * Evidence: `1604686195`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/analytics-track-digest256/86.0/1611617625](https://tracking-protection.cdn.mozilla.net/analytics-track-digest256/86.0/1611617625)
  
  
  * Method: `GET`
  
  
  * Evidence: `1611617625`
  
  
  
  
* URL: [https://tracking-protection.cdn.mozilla.net/base-cryptomining-track-digest256/86.0/1611617625](https://tracking-protection.cdn.mozilla.net/base-cryptomining-track-digest256/86.0/1611617625)
  
  
  * Method: `GET`
  
  
  * Evidence: `1611617625`
  
  
  
  
Instances: 17
  
### Solution
<p>Manually confirm that the timestamp data is not sensitive, and that the data cannot be aggregated to disclose exploitable patterns.</p>
  
### Other information
<p>1611617625, which evaluates to: 2021-01-25 15:33:45</p>
  
### Reference
* http://projects.webappsec.org/w/page/13246936/Information%20Leakage

  
#### CWE Id : 200
  
#### WASC Id : 13
  
#### Source ID : 3

  
  
  
  
### Timestamp Disclosure - Unix
##### Informational (Low)
  
  
  
  
#### Description
<p>A timestamp was disclosed by the application/web server - Unix</p>
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615896955616](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615896955616)
  
  
  * Method: `GET`
  
  
  * Evidence: `91890110`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615896955616](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615896955616)
  
  
  * Method: `GET`
  
  
  * Evidence: `26892897`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615896955616](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615896955616)
  
  
  * Method: `GET`
  
  
  * Evidence: `13369666`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615896955616](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615896955616)
  
  
  * Method: `GET`
  
  
  * Evidence: `47391665`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615896955616](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615896955616)
  
  
  * Method: `GET`
  
  
  * Evidence: `172869660`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615896955616](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615896955616)
  
  
  * Method: `GET`
  
  
  * Evidence: `15453048`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615896955616](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615896955616)
  
  
  * Method: `GET`
  
  
  * Evidence: `20012235`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615896955616](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615896955616)
  
  
  * Method: `GET`
  
  
  * Evidence: `30061037`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615896955616](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615896955616)
  
  
  * Method: `GET`
  
  
  * Evidence: `28510459`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615896955616](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615896955616)
  
  
  * Method: `GET`
  
  
  * Evidence: `49467477`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/security-state/collections/cert-revocations/changeset?_expected=1615989537021](https://firefox.settings.services.mozilla.com/v1/buckets/security-state/collections/cert-revocations/changeset?_expected=1615989537021)
  
  
  * Method: `GET`
  
  
  * Evidence: `20210313`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615896955616](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615896955616)
  
  
  * Method: `GET`
  
  
  * Evidence: `29020808`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615896955616](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615896955616)
  
  
  * Method: `GET`
  
  
  * Evidence: `28364826`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615896955616](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615896955616)
  
  
  * Method: `GET`
  
  
  * Evidence: `85176234`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615896955616](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615896955616)
  
  
  * Method: `GET`
  
  
  * Evidence: `13338833`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615896955616](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615896955616)
  
  
  * Method: `GET`
  
  
  * Evidence: `65469298`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615896955616](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615896955616)
  
  
  * Method: `GET`
  
  
  * Evidence: `169746810`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615896955616](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615896955616)
  
  
  * Method: `GET`
  
  
  * Evidence: `137272116`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615896955616](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615896955616)
  
  
  * Method: `GET`
  
  
  * Evidence: `48580249`
  
  
  
  
* URL: [https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615896955616](https://firefox.settings.services.mozilla.com/v1/buckets/main/collections/fxmonitor-breaches/changeset?_expected=1615896955616)
  
  
  * Method: `GET`
  
  
  * Evidence: `16472873`
  
  
  
  
Instances: 125
  
### Solution
<p>Manually confirm that the timestamp data is not sensitive, and that the data cannot be aggregated to disclose exploitable patterns.</p>
  
### Other information
<p>91890110, which evaluates to: 1972-11-29 05:01:50</p>
  
### Reference
* http://projects.webappsec.org/w/page/13246936/Information%20Leakage

  
#### CWE Id : 200
  
#### WASC Id : 13
  
#### Source ID : 3

  
  
  
  
### Timestamp Disclosure - Unix
##### Informational (Low)
  
  
  
  
#### Description
<p>A timestamp was disclosed by the application/web server - Unix</p>
  
  
  
* URL: [https://shavar.services.mozilla.com/downloads?client=navclient-auto-ffox&appver=86.0&pver=2.2](https://shavar.services.mozilla.com/downloads?client=navclient-auto-ffox&appver=86.0&pver=2.2)
  
  
  * Method: `POST`
  
  
  * Evidence: `1490633678`
  
  
  
  
* URL: [https://shavar.services.mozilla.com/downloads?client=navclient-auto-ffox&appver=86.0&pver=2.2](https://shavar.services.mozilla.com/downloads?client=navclient-auto-ffox&appver=86.0&pver=2.2)
  
  
  * Method: `POST`
  
  
  * Evidence: `1604686195`
  
  
  
  
* URL: [https://shavar.services.mozilla.com/downloads?client=navclient-auto-ffox&appver=86.0&pver=2.2](https://shavar.services.mozilla.com/downloads?client=navclient-auto-ffox&appver=86.0&pver=2.2)
  
  
  * Method: `POST`
  
  
  * Evidence: `1517935265`
  
  
  
  
* URL: [https://shavar.services.mozilla.com/downloads?client=navclient-auto-ffox&appver=86.0&pver=2.2](https://shavar.services.mozilla.com/downloads?client=navclient-auto-ffox&appver=86.0&pver=2.2)
  
  
  * Method: `POST`
  
  
  * Evidence: `1611617625`
  
  
  
  
Instances: 4
  
### Solution
<p>Manually confirm that the timestamp data is not sensitive, and that the data cannot be aggregated to disclose exploitable patterns.</p>
  
### Other information
<p>1490633678, which evaluates to: 2017-03-27 09:54:38</p>
  
### Reference
* http://projects.webappsec.org/w/page/13246936/Information%20Leakage

  
#### CWE Id : 200
  
#### WASC Id : 13
  
#### Source ID : 3
