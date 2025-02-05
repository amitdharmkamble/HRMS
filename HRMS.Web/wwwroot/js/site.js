// JSON raw data to named array 'results' if no 'results' key in the response
document.addEventListener("DOMContentLoaded", function () {

	htmx.defineExtension('client-side-templates', {
		transformResponse: function (text, xhr, elt) {
			const requestType = elt.getAttribute('hx-type');
			if (requestType === 'JSON') {
				const nunjucksTemplate = htmx.closest(elt, "[nunjucks-template]");
				if (nunjucksTemplate) {
					const textObject = JSON.parse(text);
					const data = 'results' in textObject ? { results: textObject.results } : { results: textObject }
					const templateName = nunjucksTemplate.getAttribute('nunjucks-template');
					const template = htmx.find('#' + templateName);
					return nunjucks.renderString(template.innerHTML, data);
				}
				return text;
			}
		}
	});
});