<a name='assembly'></a>
# TypTop.Logic

## Contents

- [Input](#T-TypTop-Logic-Input 'TypTop.Logic.Input')
  - [AllowBackspace](#F-TypTop-Logic-Input-AllowBackspace 'TypTop.Logic.Input.AllowBackspace')
  - [CaseSensitive](#F-TypTop-Logic-Input-CaseSensitive 'TypTop.Logic.Input.CaseSensitive')
  - [IgnoreNumbers](#F-TypTop-Logic-Input-IgnoreNumbers 'TypTop.Logic.Input.IgnoreNumbers')
  - [IgnorePunctuation](#F-TypTop-Logic-Input-IgnorePunctuation 'TypTop.Logic.Input.IgnorePunctuation')
  - [IgnoreSpace](#F-TypTop-Logic-Input-IgnoreSpace 'TypTop.Logic.Input.IgnoreSpace')
  - [IgnoreSpecialChar](#F-TypTop-Logic-Input-IgnoreSpecialChar 'TypTop.Logic.Input.IgnoreSpecialChar')
  - [RemoveOnFinished](#F-TypTop-Logic-Input-RemoveOnFinished 'TypTop.Logic.Input.RemoveOnFinished')
  - [RemoveOnSpace](#F-TypTop-Logic-Input-RemoveOnSpace 'TypTop.Logic.Input.RemoveOnSpace')
  - [PreviousChar](#P-TypTop-Logic-Input-PreviousChar 'TypTop.Logic.Input.PreviousChar')
  - [Backspace()](#M-TypTop-Logic-Input-Backspace 'TypTop.Logic.Input.Backspace')
  - [CheckIgnoredChars(ch)](#M-TypTop-Logic-Input-CheckIgnoredChars-System-Char- 'TypTop.Logic.Input.CheckIgnoredChars(System.Char)')
  - [CheckWord(letter,word,input)](#M-TypTop-Logic-Input-CheckWord-System-Char,TypTop-Logic-Word,System-Nullable{System-Int32}- 'TypTop.Logic.Input.CheckWord(System.Char,TypTop.Logic.Word,System.Nullable{System.Int32})')
  - [ConvertSpecialChar(ch)](#M-TypTop-Logic-Input-ConvertSpecialChar-System-Char- 'TypTop.Logic.Input.ConvertSpecialChar(System.Char)')
  - [TextInput(letter)](#M-TypTop-Logic-Input-TextInput-System-Char- 'TypTop.Logic.Input.TextInput(System.Char)')
  - [TextInput(letters)](#M-TypTop-Logic-Input-TextInput-System-String- 'TypTop.Logic.Input.TextInput(System.String)')
- [InputList](#T-TypTop-Logic-InputList 'TypTop.Logic.InputList')
  - [FocusOnHighIndex](#F-TypTop-Logic-InputList-FocusOnHighIndex 'TypTop.Logic.InputList.FocusOnHighIndex')
- [KeyWrong](#T-TypTop-Logic-Input-KeyWrong 'TypTop.Logic.Input.KeyWrong')
- [Word](#T-TypTop-Logic-Word 'TypTop.Logic.Word')
  - [Correct](#F-TypTop-Logic-Word-Correct 'TypTop.Logic.Word.Correct')
  - [Finished](#F-TypTop-Logic-Word-Finished 'TypTop.Logic.Word.Finished')
  - [Index](#P-TypTop-Logic-Word-Index 'TypTop.Logic.Word.Index')
  - [Input](#P-TypTop-Logic-Word-Input 'TypTop.Logic.Word.Input')
  - [Letters](#P-TypTop-Logic-Word-Letters 'TypTop.Logic.Word.Letters')
  - [Backspace()](#M-TypTop-Logic-Word-Backspace 'TypTop.Logic.Word.Backspace')
  - [ValidIndex(index)](#M-TypTop-Logic-Word-ValidIndex-System-Int32- 'TypTop.Logic.Word.ValidIndex(System.Int32)')
- [WordProvider](#T-TypTop-Logic-WordProvider 'TypTop.Logic.WordProvider')
  - [_wordsToServe](#F-TypTop-Logic-WordProvider-_wordsToServe 'TypTop.Logic.WordProvider._wordsToServe')
  - [MaxWordLength](#P-TypTop-Logic-WordProvider-MaxWordLength 'TypTop.Logic.WordProvider.MaxWordLength')
  - [MinWordLength](#P-TypTop-Logic-WordProvider-MinWordLength 'TypTop.Logic.WordProvider.MinWordLength')
  - [UsageChars](#P-TypTop-Logic-WordProvider-UsageChars 'TypTop.Logic.WordProvider.UsageChars')
  - [WordCount](#P-TypTop-Logic-WordProvider-WordCount 'TypTop.Logic.WordProvider.WordCount')
  - [LoadWords()](#M-TypTop-Logic-WordProvider-LoadWords 'TypTop.Logic.WordProvider.LoadWords')
  - [ResetToEmpty()](#M-TypTop-Logic-WordProvider-ResetToEmpty 'TypTop.Logic.WordProvider.ResetToEmpty')
  - [Serve(shuffle)](#M-TypTop-Logic-WordProvider-Serve-System-Boolean- 'TypTop.Logic.WordProvider.Serve(System.Boolean)')
  - [Shuffle()](#M-TypTop-Logic-WordProvider-Shuffle 'TypTop.Logic.WordProvider.Shuffle')
- [WordUpdateArgs](#T-TypTop-Logic-WordUpdateArgs 'TypTop.Logic.WordUpdateArgs')
  - [CurrentChar](#F-TypTop-Logic-WordUpdateArgs-CurrentChar 'TypTop.Logic.WordUpdateArgs.CurrentChar')
  - [PreviousChar](#F-TypTop-Logic-WordUpdateArgs-PreviousChar 'TypTop.Logic.WordUpdateArgs.PreviousChar')

<a name='T-TypTop-Logic-Input'></a>
## Input `type`

##### Namespace

TypTop.Logic

<a name='F-TypTop-Logic-Input-AllowBackspace'></a>
### AllowBackspace `constants`

##### Summary

Allow backspacing when typing a word has started. Note that backspacing will work for all the words in the list.

<a name='F-TypTop-Logic-Input-CaseSensitive'></a>
### CaseSensitive `constants`

##### Summary

Checks case-sensitivity of the input when comparing to the words. Default is true.

<a name='F-TypTop-Logic-Input-IgnoreNumbers'></a>
### IgnoreNumbers `constants`

##### Summary

Ignores numbers when true, does not count them as mistake when entered. Removes all numbers from words if they contain any.

<a name='F-TypTop-Logic-Input-IgnorePunctuation'></a>
### IgnorePunctuation `constants`

##### Summary

Ignores punctuation when true, does not count them as mistake when entered. Removes all interpunction from words if they contain any.

<a name='F-TypTop-Logic-Input-IgnoreSpace'></a>
### IgnoreSpace `constants`

##### Summary

Ignores space when true, does not count as mistake when entered. Removes all whitespaces from words if they contain any.

<a name='F-TypTop-Logic-Input-IgnoreSpecialChar'></a>
### IgnoreSpecialChar `constants`

##### Summary

Ignores special characters marks when true, converts all special characters if possible to standard characters.

<a name='F-TypTop-Logic-Input-RemoveOnFinished'></a>
### RemoveOnFinished `constants`

##### Summary

Remove the a word when it is finished.

<a name='F-TypTop-Logic-Input-RemoveOnSpace'></a>
### RemoveOnSpace `constants`

##### Summary

Remove the current word when the spacebar is pressed. Only works when IgnoreSpace is false. Note that when a list is used, all words will be removed when none of the words match.

<a name='P-TypTop-Logic-Input-PreviousChar'></a>
### PreviousChar `property`

##### Summary

The previously inputted letter with the TextInput function.

<a name='M-TypTop-Logic-Input-Backspace'></a>
### Backspace() `method`

##### Summary

Abstract methods when backspace is pressed.

##### Parameters

This method has no parameters.

<a name='M-TypTop-Logic-Input-CheckIgnoredChars-System-Char-'></a>
### CheckIgnoredChars(ch) `method`

##### Summary

Checks if the given char should be ignored according to the given settings.

##### Returns

If the char should be ignored.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| ch | [System.Char](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Char 'System.Char') | The chararacter that needs to be checked. |

<a name='M-TypTop-Logic-Input-CheckWord-System-Char,TypTop-Logic-Word,System-Nullable{System-Int32}-'></a>
### CheckWord(letter,word,input) `method`

##### Summary

Checks the given word for the given letter.

##### Returns

If the letter matches the current typing index of the word.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| letter | [System.Char](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Char 'System.Char') | The letter that was inputted by the user. |
| word | [TypTop.Logic.Word](#T-TypTop-Logic-Word 'TypTop.Logic.Word') | The word needs to be checked. |
| input | [System.Nullable{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int32}') | If set, checks a specific letterindex of the word. If not, it takes the current index and when necessary adjusts it. |

<a name='M-TypTop-Logic-Input-ConvertSpecialChar-System-Char-'></a>
### ConvertSpecialChar(ch) `method`

##### Summary

Tries to convert a special character to a normal character.

##### Returns

If possible the converted char, otherwise it returns the given char.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| ch | [System.Char](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Char 'System.Char') | The character to convert to normal. |

<a name='M-TypTop-Logic-Input-TextInput-System-Char-'></a>
### TextInput(letter) `method`

##### Summary

Updates all the requested words with the given char.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| letter | [System.Char](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Char 'System.Char') | The letter that has been entered by the users of needs to be checked. |

<a name='M-TypTop-Logic-Input-TextInput-System-String-'></a>
### TextInput(letters) `method`

##### Summary

Updates all the requested words with the given char.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| letters | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The characters that have been entered converted to char array and tested in that specific order. |

<a name='T-TypTop-Logic-InputList'></a>
## InputList `type`

##### Namespace

TypTop.Logic

<a name='F-TypTop-Logic-InputList-FocusOnHighIndex'></a>
### FocusOnHighIndex `constants`

##### Summary

When the InputMethod is set to list. Only the word with the highest typing progress will be focussed on. Interpeted as false when there is an equal typing progress.

<a name='T-TypTop-Logic-Input-KeyWrong'></a>
## KeyWrong `type`

##### Namespace

TypTop.Logic.Input

##### Summary

What does the program do when the users inputs a wrong key.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Reset | [T:TypTop.Logic.Input.KeyWrong](#T-T-TypTop-Logic-Input-KeyWrong 'T:TypTop.Logic.Input.KeyWrong') | Default. Resets the current typing progress of the word. |

<a name='T-TypTop-Logic-Word'></a>
## Word `type`

##### Namespace

TypTop.Logic

<a name='F-TypTop-Logic-Word-Correct'></a>
### Correct `constants`

##### Summary

Gives if the word was correctly typed until the current index. Returns if the word was typed correctly unless the typing has not yet started.

<a name='F-TypTop-Logic-Word-Finished'></a>
### Finished `constants`

##### Summary

Gives if the word was completely correctly typed. Returns if the word was correctly typed.

<a name='P-TypTop-Logic-Word-Index'></a>
### Index `property`

##### Summary

Index of the character that is currently being checked by the program.

<a name='P-TypTop-Logic-Word-Input'></a>
### Input `property`

##### Summary

Gives the input given by the user for this word.

<a name='P-TypTop-Logic-Word-Letters'></a>
### Letters `property`

##### Summary

The word saved as a string.

<a name='M-TypTop-Logic-Word-Backspace'></a>
### Backspace() `method`

##### Summary

Removes the last character from the Input and lowers the input by one

##### Parameters

This method has no parameters.

<a name='M-TypTop-Logic-Word-ValidIndex-System-Int32-'></a>
### ValidIndex(index) `method`

##### Summary

Checks if the given index is valid for this word.

##### Returns

True if valid.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| index | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Index of the letter in this word. |

<a name='T-TypTop-Logic-WordProvider'></a>
## WordProvider `type`

##### Namespace

TypTop.Logic

<a name='F-TypTop-Logic-WordProvider-_wordsToServe'></a>
### _wordsToServe `constants`

##### Summary

List of words to serve with conditions

<a name='P-TypTop-Logic-WordProvider-MaxWordLength'></a>
### MaxWordLength `property`

##### Summary

Max length of word.

<a name='P-TypTop-Logic-WordProvider-MinWordLength'></a>
### MinWordLength `property`

##### Summary

Min length of word.

<a name='P-TypTop-Logic-WordProvider-UsageChars'></a>
### UsageChars `property`

##### Summary

Optional: select only words with char in list.

<a name='P-TypTop-Logic-WordProvider-WordCount'></a>
### WordCount `property`

##### Summary

Amount of words to provide.

<a name='M-TypTop-Logic-WordProvider-LoadWords'></a>
### LoadWords() `method`

##### Summary

Loading words from database.

##### Parameters

This method has no parameters.

<a name='M-TypTop-Logic-WordProvider-ResetToEmpty'></a>
### ResetToEmpty() `method`

##### Summary

Reset words to initial.

##### Parameters

This method has no parameters.

<a name='M-TypTop-Logic-WordProvider-Serve-System-Boolean-'></a>
### Serve(shuffle) `method`

##### Summary

Serve the words.

##### Returns

Returns the words that apply to this condition.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| shuffle | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Shuffle the words before serving. Default is true. |

<a name='M-TypTop-Logic-WordProvider-Shuffle'></a>
### Shuffle() `method`

##### Summary

Randomizes the list

##### Parameters

This method has no parameters.

<a name='T-TypTop-Logic-WordUpdateArgs'></a>
## WordUpdateArgs `type`

##### Namespace

TypTop.Logic

<a name='F-TypTop-Logic-WordUpdateArgs-CurrentChar'></a>
### CurrentChar `constants`

##### Summary

The currently inputted letter with the TextInput function.

<a name='F-TypTop-Logic-WordUpdateArgs-PreviousChar'></a>
### PreviousChar `constants`

##### Summary

The previously inputted letter with the TextInput function.
