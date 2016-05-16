<?php
$code = $_GET['code'];
$result = [
    'variables' => [],
    'loops' => [
        'while' => [],
        'for' => [],
        'foreach' => []
    ],
    'conditionals' => []
];

//var_dump($code);

$regexVariable = '/\s*?(\$[\w]+)/';
$regexLoops = '/\s*?((for|while|foreach)\s*?\(.+\))\s+{/';
$regexConditions = '/}*\s*?((if|else\s*if)\s*?[\s\S]+?)\s+{/';
preg_match_all($regexVariable, $code, $variableList);
preg_match_all($regexLoops, $code, $loopsList, PREG_SET_ORDER);
preg_match_all($regexConditions, $code, $conditionalsList, PREG_SET_ORDER);

//var_dump($variableList[1]);
foreach ($variableList[1] as $value) {
    if (!in_array ($value , array_keys($result['variables']))) {
        $result['variables'][$value] = 0;
    }
    $result['variables'][$value]++;
}
//var_dump($loopsList);
foreach ($loopsList as $value) {
    switch ($value[2]) {
        case 'while':
            $result['loops']['while'][] = $value[1];
            break;
        case 'for':
            $result['loops']['for'][] = $value[1];
            break;
        case 'foreach':
            $result['loops']['foreach'][] = $value[1];
            break;
    }
}
//var_dump($conditionalsList);
foreach ($conditionalsList as $value) {
    $result['conditionals'][] = $value[1];
}
//var_dump($conditionsList);
//var_dump($result);
echo json_encode($result);