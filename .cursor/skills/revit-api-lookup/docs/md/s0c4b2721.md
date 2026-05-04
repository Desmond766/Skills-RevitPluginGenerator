---
kind: property
id: P:Autodesk.Revit.UI.ContextualHelp.HelpTopicUrl
source: html/8b29b7b1-baff-754b-8d76-de9d8cfd3b74.htm
---
# Autodesk.Revit.UI.ContextualHelp.HelpTopicUrl Property

The help topic URL.

## Syntax (C#)
```csharp
public string HelpTopicUrl { get; set; }
```

## Remarks
Applies only to objects of type ContextualHelpType.ChmFile. If empty or Nothing nullptr a null reference ( Nothing in Visual Basic) , the default page of the help file will be displayed.
 Obtain the URL by:
 Open the chm file and go to the page you want to show. Right click on the page, and choose the Properties command. In the middle of properties page there is a property called: Address (URL).
The end of the URL contains the topic URL used to open the help file to the correct page.
Here is an example: mk:@MSITStore:C:\RevitAPI2013.chm::/WhatsNew.htm
The help topic URL of this page is "WhatsNew.htm".
Another example: mk:@MSITStore:C:\RevitAPI2013.chm::/html/329b02eb-5ee4-1715-2fbf-2cbbc0d3ff2a.htm
The help topic URL of this page is "html/329b02eb-5ee4-1715-2fbf-2cbbc0d3ff2a.htm".

